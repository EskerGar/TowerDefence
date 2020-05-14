using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui
{
    public class UiComponent : MonoBehaviour
    {
        [Inject] private BaseBehaviour baseBehaviour;
        [Inject] private GoldComponent goldComponent;
        [SerializeField] private Text goldText;
        [SerializeField] private Text healthText;

        private void Start()
        {
            RefreshGoldView();
            RefreshHealthView();
            goldComponent.OnChange += RefreshGoldView;
            baseBehaviour.OnDamaged += RefreshHealthView;
        }

        private void RefreshGoldView() => goldText.text ="Gold: " + goldComponent.ReturnGold.ToString("F1");

        private void RefreshHealthView() => healthText.text ="Health: " +  baseBehaviour.ReturnHealth.ToString("F1");
    }
}
