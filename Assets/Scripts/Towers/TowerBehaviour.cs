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
        private TowerInfo info;
        public event Action<TowerBehaviour> OnUpdate, OnClick;

        public float Damage { get; private set; }
        public float SpeedAttack { get; private set; }
        public float Level { get; private set; } = 0;
        public float Cost { get; private set; } = 0;

        private void Start()
        {
            parametrs = GetComponent<TowerParametrs>();
            info = GetComponentInChildren<TowerInfo>();
            Damage = parametrs.Damage;
            SpeedAttack = parametrs.SpeedAttack;
            OnClick += info.ShowInfo;
            OnUpdate += info.ResetInfo;
        }

        public void UpdateStart()
        {
            OnUpdate?.Invoke(this);
        }
        
        private void OnMouseDown()
        {
            OnClick?.Invoke(this);
        }

        public void UpParametrs(float level, float damage, float attackSpeed, float cost)
        {
            Level += level;
            Damage += damage;
            SpeedAttack += attackSpeed;
            Cost = cost;
        }
        /*public class TowerFabrik : Factory<TowerBehaviour>
        {
        }*/
    }
}
