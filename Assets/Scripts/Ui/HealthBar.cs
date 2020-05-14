using UnityEngine;

namespace Ui
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform bar;
        [SerializeField] private GameObject body;
    
        private HealthComponent health;
    
        private void SetSize(float sizeNormalized) => bar.localScale = new Vector3(sizeNormalized, 1f);

        private void HealthChange()
        {
            float currentHealth = health.ReturnHealth;
            if (currentHealth > 0)
            {
                var healthValue = currentHealth / this.health.ReturnMaxHealth;
                SetSize(healthValue);
            }
            else 
                SetSize(0f);
        }
    
        private void Start()
        {
            health = body.GetComponent<HealthComponent>();
            health.OnChange += HealthChange;
        }
    }
}
