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
        private TowerSettings settings;
        [Inject] private GameManager gameManager;
        public event Action OnUpdate;

        private void Start()
        {
            OnUpdate += Update;
        }

        public void Update()
        {
            if (gameManager.Gold < minCost) return;
            settings = GetComponent<TowerBehaviour>().ReturnSettings;
            settings.damage += upDamage;
            settings.attackSpeed += upSpeedAttack;
            gameManager.Gold -= minCost;
            minCost *= costCoeff;
        }

        private void OnMouseDown()
        {
            OnUpdate?.Invoke();
        }
    }
}
