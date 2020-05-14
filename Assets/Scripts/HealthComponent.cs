﻿using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
   private float health, maxHealth;
   public float ReturnHealth => health;
   public float ReturnMaxHealth => maxHealth;
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
         health = 0;
         ProcessDeath();
         return;
      }
      OnChange?.Invoke();
   }

   private void ProcessDeath() => OnDeath?.Invoke(gameObject);

   public void InitialHealth(float maxHealth)
   {
      this.maxHealth = maxHealth;
      health = this.maxHealth;
   }
   
   
}
