using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
   [SerializeField] private float maxHealth;
   [SerializeField]private float _health;
   public event Action OnChange;

   private void Start()
   {
      _health = maxHealth;
   }

   public void ChangeHealth(float amount)
   {
      _health -= amount;
      OnChange?.Invoke();
   }
   
}
