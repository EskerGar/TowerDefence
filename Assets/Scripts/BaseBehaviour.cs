using System;
using Settings;
using UnityEngine;
using Zenject;

public class BaseBehaviour : MonoBehaviour
{
    [SerializeField] private BaseSettings baseSettings;
    [Inject] private GameManager gameManager;
    [Inject] private TimeController time;
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
        gameManager.StartEndGame();
        time.PauseOn();
    }

    public void TakeDamage(float damage)
    {
        healthComponent.TakeDamage(damage);
        OnDamaged?.Invoke();
    }
}
