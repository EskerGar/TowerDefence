using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class TowerInfo : MonoBehaviour
    {
        [SerializeField] private Text levelText;
        [SerializeField] private Text damageText;
        [SerializeField] private Text attackSpeedText;
        private Button btnUpgrade;
        void Start()
        {
            btnUpgrade = GetComponentInChildren<Button>();
            gameObject.SetActive(false);
        }

        public void ShowInfo(float level, float damage, float attackSpeed)
        {
            gameObject.SetActive(true);
            levelText.text = "Level: " + level.ToString();
            damageText.text = "Damage: " + damage.ToString();
            attackSpeedText.text = "AttackSpeed: " + attackSpeed.ToString();
        }
        
    }
}
