using Settings;
using UnityEngine;
using Zenject;

namespace Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private TowerSettings towerSettings;
        private TowerUpdate update;

        public float Damage { get; private set; }
        public float SpeedAttack { get; private set; }

        private void Start()
        {
            RefreshParametrs();
            update = GetComponent<TowerUpdate>();
            update.OnUpdate += RefreshParametrs;
        }

        private void RefreshParametrs()
        {
            Damage = towerSettings.damage;
            SpeedAttack = towerSettings.attackSpeed;
        }

        public TowerSettings ReturnSettings => towerSettings;
    
        public class TowerFabrik : Factory<TowerBehaviour>
        {
        }
    }
}
