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
        private float damageCoeffIncrease, speedAttackCoeffIncrease, costCoeffIncrease;
        public float Cost { get; private set; }

        private void Awake()
        {
            towerBehaviour = GetComponent<TowerBehaviour>();
            Damage = settings.damage;
            SpeedAttack = settings.attackSpeed;
            damageCoeffIncrease = settings.damageCoeffIncrease;
            speedAttackCoeffIncrease = settings.speedAttackCoefIncrease;
            Cost = settings.cost;
            costCoeffIncrease = settings.costCoeffIncrease;
            towerBehaviour.OnUpdate += Updated;
        }
        
        private void Updated(TowerBehaviour tower)
        {
            if (goldComponent.ReturnGold < tower.Cost) return;
            goldComponent.Buy(tower.Cost);
            var cost = tower.Cost * costCoeffIncrease;
            var damage = tower.Damage * damageCoeffIncrease;
            var speedAttack = tower.SpeedAttack * speedAttackCoeffIncrease;
            tower.UpParametrs(1, damage, speedAttack, cost);
        }
    }
}
