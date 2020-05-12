using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Settings;
using UnityEngine;
using Zenject;

public class EnemyBehaviour : MonoBehaviour
{
    [Inject] private EnemySettings _enemySettings;

    [Inject] private GameObject _target;
    private HealthComponent _healthComponent;
    public float Award { get; private set; }
    public float Damage { get; private set; }

    private void Awake()
    {
        GetComponent<AIDestinationSetter>().target = _target.transform;
    }

    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        Damage = _enemySettings.damage;
        Award = _enemySettings.award;
        _healthComponent.InitialHealth(_enemySettings.health);
    }
    
    public void TakeDamage(float damage)
    {
        _healthComponent.TakeDamage(damage);
    }

    public class EnemyFabrik : Factory<EnemyBehaviour>
    {
    }
}
