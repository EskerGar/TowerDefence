using System;
using Pathfinding;
using Settings;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [Inject] private GameObject target;
        private EnemyParametrs parametrs;
        private HealthComponent healthComponent;
        [Inject] private EnemyPool enemyPool;
        [Inject] private GameManager gameManager;
        [Inject] private GoldComponent goldComponent;
        [SerializeField] private float koeffIncrease = 1.5f;
        public float Award { get; private set; }
        public float Damage { get; private set; }
        public event Action<float> OnUpdate;

        private void Awake()
        {
            GetComponent<AIDestinationSetter>().target = target.transform;
            parametrs = GetComponent<EnemyParametrs>();
        }

        public void Initialize()
        {
            healthComponent.InitialHealth(parametrs.Health);
            Damage = parametrs.Damage;
            Award = parametrs.Award;
            healthComponent.OnDeath += WhenDead;
            healthComponent.OnDeath += goldComponent.AddForEnemy;
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
            healthComponent.OnDeath -= goldComponent.AddForEnemy;
            healthComponent.OnDeath -= gameManager.AddKill;
            gameManager.OnNextWave -= PowerUp;
            enemyPool.DeactivateEnemy(go);
        }

        private void PowerUp(int count)
        {
            OnUpdate?.Invoke(koeffIncrease);

        }

        public void SubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath += method;

        public void UnsubscribeOnDeath(Action<GameObject> method) => healthComponent.OnDeath -= method;
        public class EnemyFabrik : Factory<EnemyBehaviour>
        {
        }
    }
}
