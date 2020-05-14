using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerSettings : ScriptableObject
    {
        [Min(0)] public float damage;
        [Min(0)] public float attackSpeed;
        [Min(0)] public float upDamage;
        [Min(0)] public float upSpeedAttack;
        [Min(0)] public float cost;
        [Min(0)] public float costCoeff;
    }
}
