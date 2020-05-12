using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig")]
public class EnemySettings : ScriptableObject
{
    public float damage;
    public float health;
    public float award;
}
