using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class GoldComponent : MonoBehaviour
{
    private float gold = 0;
    public float ReturnGold => gold;
    public event Action OnChange;

    public void Buy(float amount)
    {
        ProcessChanging(-amount);
    }

    private void ProcessChanging(float amount)
    {
        gold += amount;
        OnChange?.Invoke();
    }

    public void AddForEnemy(GameObject enemy)
    {
        var amount = enemy.GetComponent<EnemyBehaviour>().Award;
        Add(amount);
    }

    private void Add(float amount)
    {
        ProcessChanging(amount);
    }
    
}
