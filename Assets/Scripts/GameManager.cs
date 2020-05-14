using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private int killCount;
    private float delayBetweenWaves;
    private bool endGame = false;
    [Tooltip("Дополнительное количество врагов к волне")]
    [SerializeField] private int addEnemy;
    [Inject] private Files file;
    private int waveCount = 0;
    public event Action<int> OnNextWave, OnEndGame;

    public void AddKill() => killCount++;

    private void Start()
    {
        var config = file.ReadConfigFile();
        delayBetweenWaves = config.delayBetweenWaves;
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
        yield return new WaitForSeconds(delayBetweenWaves);
        while (!endGame)
        {
            NextWave();
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }
}
