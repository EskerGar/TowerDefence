using Settings;
using UnityEngine;
using Zenject;

public class BaseBehaviour : MonoBehaviour
{
    [SerializeField] private BaseSettings baseSettings;
    private HealthComponent healthComponent;
    
    private void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.InitialHealth(baseSettings.health);
        healthComponent.OnDeath += Death;
    }

    private void Death(GameObject go = null)
    {
        Time.timeScale = 0;
    }

    public void TakeDamage(float damage) => healthComponent.TakeDamage(damage);
}
