using System;
using Settings;
using UnityEngine;
using Zenject;

namespace Towers
{
    public class TowerUpdate : MonoBehaviour
    {
        [SerializeField] private float upDamage;
        [SerializeField] private float upSpeedAttack;
        [SerializeField] private float cost;
        [SerializeField] private float costCoeff;
        [Inject] private GoldComponent goldComponent;
        private TowerBehaviour tower;

        private void Awake()
        {
            tower = GetComponent<TowerBehaviour>();
            tower.OnUpdate += Updated;
        }

        private void Updated(TowerBehaviour tower)
        {
            if (goldComponent.ReturnGold < cost) return;
            goldComponent.Buy(cost);
            cost *= costCoeff;
            tower.UpParametrs(1, upDamage, upSpeedAttack, cost);
        }
    }
}
