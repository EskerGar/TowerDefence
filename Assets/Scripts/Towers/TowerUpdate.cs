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
        [SerializeField] private float minCost;
        [SerializeField] private float costCoeff;
        [Inject] private GoldComponent goldComponent;
        private TowerBehaviour tower;

        private void Start()
        {
            tower = GetComponent<TowerBehaviour>();
            tower.OnUpdate += Updated;
        }

        private void Updated(float damage, float attackSpeed, float level)
        {
            if (goldComponent.ReturnGold < minCost) return;
            damage += upDamage;
            attackSpeed += upSpeedAttack;
            level++;
            goldComponent.Buy(minCost);
            minCost *= costCoeff;
        }
    }
}
