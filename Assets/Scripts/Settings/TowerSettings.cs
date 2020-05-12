using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerSettings : ScriptableObject
    {
       [Min(0)] public float damage;
       [Min(0)] public int attackSpeed;
    }
}
