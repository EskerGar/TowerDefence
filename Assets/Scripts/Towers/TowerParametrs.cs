using Settings;
using UnityEngine;
using Zenject;

namespace Towers
{
    public class TowerParametrs : MonoBehaviour
    {
        [SerializeField] private TowerSettings settings;
        [Inject] private GoldComponent goldComponent;
        private TowerBehaviour towerBehaviour;
        public float Damage { get; private set; }
        public float SpeedAttack { get; private set; }
        private float UpDamage { get; set; }
        private float UpSpeedAttack { get; set; }
        public float Cost { get; private set; }
        private float CostCoeff { get; set; }

        private void Awake()
        {
            towerBehaviour = GetComponent<TowerBehaviour>();
            Damage = settings.damage;
            SpeedAttack = settings.attackSpeed;
            UpDamage = settings.upDamage;
            UpSpeedAttack = settings.upSpeedAttack;
            Cost = settings.cost;
            CostCoeff = settings.costCoeff;
            towerBehaviour.OnUpdate += Updated;
        }
        
        private void Updated(TowerBehaviour tower)
        {
            if (goldComponent.ReturnGold < tower.Cost) return;
            goldComponent.Buy(tower.Cost);
            var cost = tower.Cost * CostCoeff;
            tower.UpParametrs(1, UpDamage, UpSpeedAttack, cost);
        }
    }
}
