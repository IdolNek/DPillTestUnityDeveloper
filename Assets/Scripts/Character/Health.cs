using System;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _maxHealth;
        [SerializeField]
        private float _currentHealth;

        public float CurrentHealth => _currentHealth;

        public event Action<float, float> OnHealthChanged;
        public void Initialize(float health)
        {
            _maxHealth = health;
            ResetHP();
        }

        public void ResetHP()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= Math.Clamp(damage, 0, _currentHealth);
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}