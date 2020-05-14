using System;
using Towers;
using UnityEngine;

namespace Ui
{
    public class TowerUi : MonoBehaviour
    {
        private TowerBehaviour towerBehaviour;
        private TextMesh text;

        private void Start()
        {
            towerBehaviour = GetComponentInParent<TowerBehaviour>();
            text = GetComponent<TextMesh>();
            text.text = "0";
            towerBehaviour.OnUpdate += LevelUpdateView;
        }

        private void LevelUpdateView(TowerBehaviour tower)
        {
            text.text = tower.Level.ToString();
        }
    }
}
