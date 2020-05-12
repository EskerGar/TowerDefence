using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerSpawner : Spawner
{
    [Inject] private EnemyBehaviour.EnemyFabrik _fabrik;

    public void StartSpawn()
    {
        
    }

    private void Start()
    {
        Fabrik();
    }

    protected override IEnumerator Fabrik()
    {
        var enemy =  _fabrik.Create();
            enemy.transform.position = transform.position;
            yield break;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one );
    }
}
