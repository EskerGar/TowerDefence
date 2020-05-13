using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemySettings : ScriptableObject
    {
        [Min(0)] public float damage;
        [Min(0)] public float health;
        [Min(0)] public float award;
    }
}
