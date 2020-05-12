using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Settings;
using UnityEngine;
using Zenject;

public class BaseBehaviour : MonoBehaviour
{
    [Inject] private BaseSettings _enemySettings;

    [Inject] private GameObject _target;
    private HealthComponent _healthComponent;
    
    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _healthComponent.InitialHealth(_enemySettings.health);
    }

    public void TakeDamage(float damage) => _healthComponent.TakeDamage(damage);
}
