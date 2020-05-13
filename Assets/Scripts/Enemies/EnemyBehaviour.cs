using System;
using Pathfinding;
using Settings;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemySettings enemySettings;
        [Inject] private GameObject target;
        private EnemyPowerUp powerUp;
        private HealthComponent healthComponent;
        [Inject] private EnemyPool enemyPool;
        [Inject] private GameManager gameManager;
        [SerializeField] private float koeffIncrease;
        public float Award { get; private set; }
        public float Damage { get; private set; }

        private void Awake()
        {
            GetComponent<AIDestinationSetter>().target = target.transform;
            powerUp = GetComponent<EnemyPowerUp>();
        }

        public void Initialize()
        {
            healthComponent.InitialHealth(enemySettings.health);
            Damage = enemySettings.damage;
            Award = enemySettings.award;
            healthComponent.OnDeath += WhenDead;
            healthComponent.OnDeath += gameManager.AddGold;
            healthComponent.OnDeath += gameManager.AddKill;
            gameManager.OnNextWave += PowerUp;
        }
    
        private void Start()
        {
            healthComponent = GetComponent<HealthComponent>();
            Initialize();
        }
    
        public void TakeDamage(float damage)
        {
            healthComponent.TakeDamage(damage);
        }

        public void Suicide()
        {
            healthComponent.TakeDamage(healthComponent.ReturnHealth);
        }

        private void WhenDead(GameObject go)
        {
            healthComponent.OnDeath -= WhenDead;
            healthComponent.OnDeath -= gameManager.AddGold;
            healthComponent.OnDeath -= gameManager.AddKill;
            gameManager.OnNextWave -= PowerUp;
            enemyPool.DeactivateEnemy(go);
        }

        public void PowerUp(int count)
        {
            powerUp.ParametrUp(enemySettings.damage, koeffIncrease);
            powerUp.ParametrUp(enemySettings.award, koeffIncrease);
            powerUp.ParametrUp(enemySettings.health, koeffIncrease);
        }

        public void SubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath += method;

        public void UnsubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath -= method;

        public class EnemyFabrik : Factory<EnemyBehaviour>
        {
        }
    }
}
