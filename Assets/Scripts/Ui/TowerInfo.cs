using Towers;
using UnityEngine;
using UnityEngine.UI;
using Outline = cakeslice.Outline;

namespace Ui
{
    public class TowerInfo : MonoBehaviour
    {
        [SerializeField] private Text levelText;
        [SerializeField] private Text damageText;
        [SerializeField] private Text attackSpeedText;
        [SerializeField] private Text costText;
        private TowerBehaviour currentTower;
        public TowerBehaviour ReturnCurrentTower => currentTower;

        private void Start() => gameObject.SetActive(false);

        public void ShowInfo(TowerBehaviour tower)
        {
            if (currentTower != null)
                currentTower.GetComponent<Outline>().enabled = false;
            currentTower = tower;
            currentTower.GetComponent<Outline>().enabled = true;
            gameObject.SetActive(true);
            ResetInfo(tower);
        }

        public void ResetInfo(TowerBehaviour tower)
        {
            levelText.text = "Level: " + tower.Level.ToString();
            damageText.text = "Damage: " + tower.Damage.ToString("F1");
            attackSpeedText.text = "AttackSpeed: " + tower.SpeedAttack.ToString("F1");
            costText.text = "Cost: " + tower.Cost.ToString("F1");
        }

        public void Close()
        {
            currentTower.GetComponent<Outline>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
