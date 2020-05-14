using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;
using Zenject;

public class TowerSpawner: MonoBehaviour
{
    //[Inject] private TowerBehaviour.TowerFabrik fabrik;
    [SerializeField] private GameObject go;
    private void Start()
    {
        var tower =  Instantiate(go);
        tower.transform.position = transform.position;
        Destroy(gameObject);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one );
    }
}
