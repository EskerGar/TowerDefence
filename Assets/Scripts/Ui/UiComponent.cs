using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui
{
    public class UiComponent : MonoBehaviour
    {
        [Inject] private BaseBehaviour baseBehaviour;
        [Inject] private GoldComponent goldComponent;
        [Inject] private FloatRound floatRound;
        [SerializeField] private Text goldText;
        [SerializeField] private Text healthText;

        private void Start()
        {
            RefreshGoldView();
            RefreshHealthView();
            goldComponent.OnChange += RefreshGoldView;
            baseBehaviour.OnDamaged += RefreshHealthView;
        }

        private void RefreshGoldView()
        {
            goldText.text ="Gold: " + floatRound.Convert(goldComponent.ReturnGold).ToString();
        }

        private void RefreshHealthView()
        {
            healthText.text ="Health: " +  floatRound.Convert(baseBehaviour.ReturnHealth).ToString();
        }
    }
}
