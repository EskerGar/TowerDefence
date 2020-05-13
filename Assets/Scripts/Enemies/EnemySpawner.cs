using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float delayBetweenSpawn;
    [Inject] private EnemyBehaviour.EnemyFabrik fabrik;
    [Inject] private EnemyPool enemyPool;
    [Inject] private GameManager gameManager;

    private void Start()
    {
        gameManager.OnNextWave += StartSpawn;
    }

    public void StartSpawn(int spawnCount) => StartCoroutine(Fabrik(spawnCount));

    private IEnumerator Fabrik(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var enemy = enemyPool.ActivatedEnemy();
            if (enemy == null)
            {
                enemy = fabrik.Create().gameObject;
                enemyPool.AddEnemy(enemy.gameObject);
            } else enemy.GetComponent<EnemyBehaviour>().Initialize();
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, Vector3.one );
    }
}