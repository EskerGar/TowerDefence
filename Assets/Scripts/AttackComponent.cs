using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private GameObject _target;
    private Enemy _enemy;
    private EnemySettings _settings;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        if (_enemy == null) return;
        _settings = _enemy.ReturnSettings as EnemySettings;
        _target = _enemy.Target;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.Equals(_target))
            _target.GetComponent<HealthComponent>().ChangeHealth(_settings.damage);
    }
}
