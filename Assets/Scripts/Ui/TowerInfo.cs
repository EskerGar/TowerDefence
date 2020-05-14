using System;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class TowerInfo : MonoBehaviour
    {
        [SerializeField] private Text levelText;
        [SerializeField] private Text damageText;
        [SerializeField] private Text attackSpeedText;
        [SerializeField] private Text costText;
        [SerializeField] private Button btnUpgrade;
        public Button ReturnButton => btnUpgrade;

        public void ShowInfo(TowerBehaviour tower)
        {
            gameObject.SetActive(true);
            ResetInfo(tower);
        }

        public void ResetInfo(TowerBehaviour tower)
        {
            levelText.text = "Level: " + tower.Level.ToString();
            damageText.text = "Damage: " + tower.Damage.ToString();
            attackSpeedText.text = "AttackSpeed: " + tower.SpeedAttack.ToString();
            costText.text = "Cost: " + tower.Cost.ToString();
        }
        
    }
}
