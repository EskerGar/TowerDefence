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
        [Min(0)] public float damageCoeffIncrease;
        [Min(0)] public float healthCoeffIncrease;
        [Min(0)] public float awardCoeffIncrease;

    }
}
