using System;
using Ui;
using UnityEngine;
using Zenject;

namespace Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        private TowerParametrs parametrs;
        [Inject]private TowerInfo info;
        public event Action<TowerBehaviour> OnUpdate, OnClick;

        public float Damage { get; private set; }
        public float SpeedAttack { get; private set; }
        public float Level { get; private set; } = 0;
        public float Cost { get; private set; }

        private void Start()
        {
            parametrs = GetComponent<TowerParametrs>();
            Damage = parametrs.Damage;
            SpeedAttack = parametrs.SpeedAttack;
            Cost = parametrs.Cost;
            OnClick += info.ShowInfo;
            OnUpdate += info.ResetInfo;
        }

        public void UpdateStart() => OnUpdate?.Invoke(this);

        private void OnMouseDown() => OnClick?.Invoke(this);

        public void UpParametrs(float level, float damage, float attackSpeed, float cost)
        {
            Level += level;
            Damage += damage;
            SpeedAttack += attackSpeed;
            Cost += cost;
        }
    }
}
