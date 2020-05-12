using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject ob;
    [SerializeField] private GameObject ourBase;
    public override void InstallBindings()
    {

        Container.BindInstance(ourBase);
        Container.BindFactory<EnemyBehaviour, EnemyBehaviour.EnemyFabrik>().FromNewComponentOnNewPrefab(ob);
    }
}
