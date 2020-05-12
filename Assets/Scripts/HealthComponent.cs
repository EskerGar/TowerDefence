using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
   private float _health;
   public float ReturnHealth => _health;
   public event Action OnChange;
   public event Action<GameObject> OnDeath;

   public void TakeDamage(float amount)
   {
      _health -= amount;
      ProcessChanging();
   }

   private void ProcessChanging()
   {
      if (_health <= 0)
      {
         ProcessDeath();
         return;
      }
      OnChange?.Invoke();
   }

   private void ProcessDeath()
   {
      OnDeath?.Invoke(gameObject);
   }

   public void InitialHealth(float maxHealth)
   {
      _health = maxHealth;
   }
   
   
}
