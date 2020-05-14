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
            private float damageCoeffIncrease, healthCoeffIncrease, awardCoeffIncrease;
            [Inject] private GameManager gameManager;
            public event Action<float, float, float> OnUpdate;
            private void Awake()
            {
                Damage = settings.damage;
                Award = settings.award;
                Health = settings.health;
                damageCoeffIncrease = settings.damageCoeffIncrease;
                healthCoeffIncrease = settings.healthCoeffIncrease;
                awardCoeffIncrease = settings.awardCoeffIncrease;
                OnUpdate += UpdateEnemy;
                gameManager.OnNextWave += UpParametrs;
            }
            
            private void UpdateEnemy(float damageCoeff, float healthCoeff, float awardCoeff)
            {
                while (true)
                {
                    Damage += UpParametr(Damage, damageCoeff);
                    Health += UpParametr(Health, healthCoeff);
                    Award += UpParametr(Award, awardCoeff);
                    if (!updated)
                        continue;
                    updated = false;
                    break;
                }
            }

            private float UpParametr(float parametr, float coeff)
            {
                var value = (parametr * coeff) * Random.Range(0, 2);
                if (value > 0)
                    updated = true;
                return value;
            }

            private void UpParametrs(int count) => OnUpdate?.Invoke(damageCoeffIncrease, healthCoeffIncrease, awardCoeffIncrease);
        }
    }
