using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;

public class TowerParametrs : MonoBehaviour
{
    [SerializeField] private TowerSettings settings;
    public float Damage { get; private set; }
    public float SpeedAttack { get; private set; }

    private void Awake()
    {
        Damage = settings.damage;
        SpeedAttack = settings.attackSpeed;
    }
}
