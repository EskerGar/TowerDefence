using System.Collections;
using System.Collections.Generic;
using Enemies;
using ModestTree;
using UnityEngine;

namespace Towers
{
    public class TowerAttack : MonoBehaviour
    {
        private TowerBehaviour tower;
        private readonly List<GameObject> targetList = new List<GameObject>();
        private HealthComponent health;
        private Coroutine attackCoroutine;

        private void Start()
        {
            tower = GetComponent<TowerBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.GetComponent<EnemyBehaviour>()) return; 
            targetList.Add(other.gameObject);
            other.gameObject.GetComponent<EnemyBehaviour>().SubscribeOnDeath(TargetDead);
            if(attackCoroutine == null)
                attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!targetList.Find((x) => x.Equals(other.gameObject))) return;
            other.gameObject.GetComponent<EnemyBehaviour>().UnsubscribeOnDeath(TargetDead);
            targetList.Remove(other.gameObject);
        }

        private IEnumerator AttackCoroutine()
        {
            while (!targetList.IsEmpty())
            {
                targetList[0].GetComponent<EnemyBehaviour>().TakeDamage(tower.Damage);
                yield return new WaitForSeconds(1f/tower.SpeedAttack);
            }
            attackCoroutine = null;
        }

        private void TargetDead(GameObject deadMan)
        {
            targetList.Remove(deadMan);
            deadMan.GetComponent<EnemyBehaviour>().UnsubscribeOnDeath(TargetDead);
        }
    }
}
