using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;
using Zenject;

public class TowerSpawner: MonoBehaviour
{
    [Inject] private TowerBehaviour.TowerFabrik fabrik;

    private void Start()
    {
        var tower =  fabrik.Create();
        tower.transform.position = transform.position;
        Destroy(gameObject);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one );
    }
}
