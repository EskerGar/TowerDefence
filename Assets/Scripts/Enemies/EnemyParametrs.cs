    using System;
    using Settings;
    using UnityEngine;
    using Random = UnityEngine.Random;

    namespace Enemies
    {
        public class EnemyParametrs: MonoBehaviour
        {
            private EnemyBehaviour enemyBehaviour;
            public float Damage { get; private set; }
            public float Award { get; private set; }
            public float Health { get; private set; }
            [SerializeField] private EnemySettings settings;

            private void Awake()
            {
                Damage = settings.damage;
                Award = settings.award;
                Health = settings.health;
            }

            private void Start()
            {
                enemyBehaviour = GetComponent<EnemyBehaviour>();
                enemyBehaviour.OnUpdate += UpdateEnemy;
            }

            private void ParametrUp(float parametr, float koeffIncrease) => parametr += (parametr * koeffIncrease) * Random.Range(0, 1);

            private void UpdateEnemy( float koeffIncrease)
            {
               ParametrUp(Damage, koeffIncrease);
               ParametrUp(Health, koeffIncrease);
               ParametrUp(Award, koeffIncrease);
            }

            private void OnDestroy()
            {
                enemyBehaviour.OnUpdate -= UpdateEnemy;
            }
        }
    }
