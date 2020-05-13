    using UnityEngine;

    namespace Enemies
    {
        public class EnemyPowerUp: MonoBehaviour
        {
            public float ParametrUp(float parametr, float koeffIncrease) => parametr += (parametr * koeffIncrease) * Random.Range(0, 1);
        }
    }
