﻿using Enemies;
using Towers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject tower;
        [SerializeField] private GameObject ourBase;
        public override void InstallBindings()
        {

            Container.BindInstance(ourBase);
            Container.Bind<EnemyPool>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindFactory<EnemyBehaviour, EnemyBehaviour.EnemyFabrik>().FromNewComponentOnNewPrefab(enemy);
            Container.BindFactory<TowerBehaviour, TowerBehaviour.TowerFabrik>().FromNewComponentOnNewPrefab(tower);
        }
    }
}