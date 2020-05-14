using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerSettings : ScriptableObject
    {
        [Min(0)] public float damage;
        [Min(0)] public float attackSpeed;
        [Min(0)] public float damageCoeffIncrease;
        [Min(0)] public float speedAttackCoefIncrease;
        [Min(0)] public float cost;
        [Min(0)] public float costCoeffIncrease;
    }
}
