using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ui
{
    public class EndGame : MonoBehaviour
    {
        [Inject] private GameManager gameManager;
        [SerializeField] private Text killText;

        private void Start()
        {
            gameManager.OnEndGame += ShowResults;
            gameObject.SetActive(false);
        }

        private void ShowResults(int count)
        {
            gameObject.SetActive(true);
            killText.text = count.ToString();
        }
    }
}
