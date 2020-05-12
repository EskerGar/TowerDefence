using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree;
using Settings;
using UnityEngine;
using Zenject;

public class TowerAttack : MonoBehaviour
{
    [Inject]private TowerSettings _settings;
    private readonly List<GameObject> _targetList = new List<GameObject>();
    private HealthComponent _health;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<EnemyBehaviour>()) return; 
        _targetList.Add(other.gameObject);
        //_health.OnDeath += TargetDead;
        StartCoroutine(AttackCoroutine());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_targetList.Find((x) => x.Equals(other.gameObject)))
            _targetList.Remove(other.gameObject);
    }

    private IEnumerator AttackCoroutine()
    {
        while (!_targetList.IsEmpty())
        {
            _targetList[0].GetComponent<EnemyBehaviour>().TakeDamage(_settings.damage);
            Debug.LogError(_targetList[0].GetComponent<HealthComponent>().ReturnHealth);
            yield return new WaitForSeconds(1f/(float)_settings.attackSpeed);
        }
    }

    private void TargetDead(GameObject deadMan)
    {
        _targetList.Remove(deadMan);
        _health.OnDeath -= TargetDead;
    }
}
