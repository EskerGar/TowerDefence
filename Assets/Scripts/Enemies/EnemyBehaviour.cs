using System;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [Inject] private GameObject target;
        [Inject] private EnemyParametrs parametrs;
        private HealthComponent healthComponent;
        [Inject] private EnemyPool enemyPool;
        public bool IsSuicide { get; private set; } = false;
        public float Award { get; private set; }
        public float Damage { get; private set; }

        private void Awake() => GetComponent<AIDestinationSetter>().target = target.transform;

        public void Initialize()
        {
            healthComponent.InitialHealth(parametrs.Health);
            Damage = parametrs.Damage;
            Award = parametrs.Award;
            healthComponent.OnDeath += WhenDead;
        }
    
        private void Start()
        {
            healthComponent = GetComponent<HealthComponent>();
            Initialize();
        }
    
        public void TakeDamage(float damage) => healthComponent.TakeDamage(damage);

        public void Suicide()
        {
            IsSuicide = true;
            healthComponent.TakeDamage(healthComponent.ReturnHealth);
        }

        private void WhenDead(GameObject go)
        {
            healthComponent.OnDeath -= WhenDead;
            enemyPool.DeactivateEnemy(go);
        }
        
        public void SubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath += method;

        public void UnsubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath -= method;
        public class EnemyFabrik : Factory<EnemyBehaviour>
        {
        }
    }
}
