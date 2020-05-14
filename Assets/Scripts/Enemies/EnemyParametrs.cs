    using System;
    using Settings;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    namespace Enemies
    {
        public class EnemyParametrs : MonoBehaviour
        {
            public float Damage { get; private set; }
            public float Award { get; private set; }
            public float Health { get; private set; }
            private bool updated = false;
            [Inject] private EnemySettings settings;
            [SerializeField] private float koeffIncrease = .5f;
            [Inject] private GameManager gameManager;
            public event Action<float> OnUpdate;
            private void Awake()
            {
                Damage = settings.damage;
                Award = settings.award;
                Health = settings.health;
                OnUpdate += UpdateEnemy;
                gameManager.OnNextWave += UpParametrs;
            }
            
            private void UpdateEnemy(float koeffIncrease)
            {
                while (true)
                {
                    Damage += UpParametr(Damage, koeffIncrease);
                    Health += UpParametr(Health, koeffIncrease);
                    Award += UpParametr(Award, koeffIncrease);
                    if (!updated)
                        continue;
                    updated = false;
                    break;
                }
            }

            private float UpParametr(float parametr, float koeff)
            {
                var value = (parametr * koeff) * Random.Range(0, 2);
                if (value > 0)
                    updated = true;
                return value;
            }

            private void UpParametrs(int count)
            {
                OnUpdate?.Invoke(koeffIncrease);   
            }
        }
    }
