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
    private int killCount;
    private float delayBetweenWaves  = 5f;
    private bool endGame = false;
    [Tooltip("Дополнительное количество врагов к волне")]
    [SerializeField] private int addEnemy;
    [Inject] private TimeController time;
    private int waveCount = 0;
    public event Action<int> OnNextWave, OnEndGame;

    public void AddKill() => killCount++;

    private void Start()
    {
        StartCoroutine(NextWaveCoroutine());
    }

    public void StartEndGame()
    {
        endGame = true;
        OnEndGame?.Invoke(killCount);
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
