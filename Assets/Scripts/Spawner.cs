using System.Collections;
using UnityEngine;


public abstract class Spawner : MonoBehaviour
{
    protected abstract IEnumerator Fabrik();
}

