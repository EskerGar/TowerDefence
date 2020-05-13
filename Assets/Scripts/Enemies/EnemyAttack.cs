using System;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [Inject] private GameObject target;
         private EnemyBehaviour enemy;
        [Inject] private BaseBehaviour baseBehaviour;

        private void Start()
        {
            enemy = GetComponent<EnemyBehaviour>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.Equals(target)) return;
            baseBehaviour.TakeDamage(enemy.Damage);
            enemy.Suicide();
        }
    }
}
