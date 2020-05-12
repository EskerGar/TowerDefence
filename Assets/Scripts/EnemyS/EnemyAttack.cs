using Settings;
using UnityEngine;
using Zenject;

public class EnemyAttack : MonoBehaviour
{
    [Inject] private GameObject _target;
    [Inject] private EnemyBehaviour _enemy;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.Equals(_target))
            _target.GetComponent<BaseBehaviour>().TakeDamage(_enemy.Damage);
    }
}
