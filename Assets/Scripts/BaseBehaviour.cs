using System;
using Settings;
using UnityEngine;
using Zenject;

public class BaseBehaviour : MonoBehaviour
{
    [SerializeField] private BaseSettings baseSettings;
    private HealthComponent healthComponent;
    public event Action OnDamaged;
    
    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.InitialHealth(baseSettings.health);
        healthComponent.OnDeath += Death;
    }

    public float ReturnHealth => healthComponent.ReturnHealth;

    private void Death(GameObject go = null)
    {
        Time.timeScale = 0;
    }

    public void TakeDamage(float damage)
    {
        healthComponent.TakeDamage(damage);
        OnDamaged?.Invoke();
    }
}
