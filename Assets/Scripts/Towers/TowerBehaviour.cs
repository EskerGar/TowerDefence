using System;
using Settings;
using Ui;
using UnityEngine;
using Zenject;

namespace Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        private TowerParametrs parametrs;
        [Inject] private TowerInfo info;
        public event Action<float, float, float> OnUpdate, OnClick;

        public float Damage { get; private set; }
        public float SpeedAttack { get; private set; }
        public float Level { get; private set; } = 0;

        private void Start()
        {
            parametrs = GetComponent<TowerParametrs>();
            Damage = parametrs.Damage;
            SpeedAttack = parametrs.SpeedAttack;
            OnClick += info.ShowInfo;
        }
        
        private void OnMouseDown()
        {
            OnClick?.Invoke(Level, Damage, SpeedAttack);
        }
        public class TowerFabrik : Factory<TowerBehaviour>
        {
        }
    }
}
