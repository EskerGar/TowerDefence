using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Enemies
{
    public class EnemyPool : MonoBehaviour
    {
        private readonly List<GameObject> activeEnemy = new List<GameObject>();
        private readonly List<GameObject> deactiveEnemy = new List<GameObject>();

        public void DeactivateEnemy(GameObject enemy)
        {
            activeEnemy.Remove(enemy);
            deactiveEnemy.Add(enemy);
            enemy.SetActive(false);
        }

        public GameObject ActivatedEnemy()
        {
            if (deactiveEnemy.IsEmpty()) return null;
            var enemy = deactiveEnemy[0];
            enemy.SetActive(true);
            AddEnemy(enemy);
            deactiveEnemy.RemoveAt(0);
            return enemy;
        }

        public void AddEnemy(GameObject enemy) => activeEnemy.Add(enemy);
    }
}
