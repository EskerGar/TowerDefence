using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "BaseConfig", menuName = "Configs/BaseConfig")]
    public class BaseSettings : ScriptableObject
    {
       [Min(0)] public float health;
    }
}
