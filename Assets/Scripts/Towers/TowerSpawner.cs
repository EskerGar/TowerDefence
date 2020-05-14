using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;
using Zenject;

public class TowerSpawner: MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    private void Start()
    {
        var tower =  Instantiate(spawnObject);
        tower.transform.position = transform.position;
        Destroy(gameObject);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one );
    }
}
