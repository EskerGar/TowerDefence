using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "SoInstaller")]
public class SoInstaller : ScriptableObjectInstaller
{

    [SerializeField] private EnemySettings enemySettings;
    [SerializeField] private TowerSettings towerSettings;
    [SerializeField] private BaseSettings baseSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(enemySettings);
        Container.BindInstance(towerSettings);
        Container.BindInstance(baseSettings);
    }
}
