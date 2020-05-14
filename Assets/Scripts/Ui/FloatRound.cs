using UnityEngine;

namespace Ui
{
    public class FloatRound : MonoBehaviour
    {
        public float Convert(float number)
        {
            return (float) (System.Math.Truncate(number * 100.0) / 100.0);
        }
    }
}
