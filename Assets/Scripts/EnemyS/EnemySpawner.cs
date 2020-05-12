using System.Collections;
using UnityEngine;
using Zenject;

public class EnemySpawner : Spawner
{
    [SerializeField] private int spawnCount;
    [SerializeField] private float delayBetweenSpawn;
    [Inject] private EnemyBehaviour.EnemyFabrik _fabrik;

    public void StartSpawn()
    {
        
    }

    private void Start()
    {
        StartCoroutine(Fabrik());
    }

    protected override IEnumerator Fabrik()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            var enemy =  _fabrik.Create();
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