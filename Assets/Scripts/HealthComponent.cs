using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
   [SerializeField] private float maxHealth;
   private float _health;
   public event Action OnChange;

   private void ChangeHealth(float amount)
   {
      _health -= amount;
      OnChange?.Invoke();
   }
   
}
