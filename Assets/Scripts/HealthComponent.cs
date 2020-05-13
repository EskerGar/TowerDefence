using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
   [SerializeField]private float health;
   public float ReturnHealth => health;
   public event Action OnChange;
   public event Action<GameObject> OnDeath;

   public void TakeDamage(float amount)
   {
      health -= amount;
      ProcessChanging();
   }

   private void ProcessChanging()
   {
      if (health <= 0)
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
      health = maxHealth;
   }
   
   
}
