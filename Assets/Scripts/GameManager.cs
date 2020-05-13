using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemySpawnerList = new List<GameObject>();
    public float Gold { get; set; }
    private int killCount;
    private float delayBetweenWaves  = 5f;
    private bool endGame = false;
    [Tooltip("Дополнительное количество врагов к волне")]
    [SerializeField] private int addEnemy;
    private int waveCount = 0;
    public event Action<int> OnNextWave;

    public void AddGold(GameObject enemy) => Gold = enemy.GetComponent<EnemyBehaviour>().Award;

    public void AddKill(GameObject enemy) => killCount++;

    private void Start()
    {
        StartCoroutine(NextWaveCoroutine());
    }

    private void NextWave()
    {
        waveCount++;
        int enemiesCount = Random.Range(waveCount, waveCount + addEnemy);
        OnNextWave?.Invoke(enemiesCount);
    }

    private IEnumerator NextWaveCoroutine()
    {
        while (!endGame)
        {
            NextWave();
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }
    
}
