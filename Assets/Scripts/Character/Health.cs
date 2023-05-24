using System;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Health : MonoBehaviour
    {
        private float _maxHealth;
        private float _currentHealth;

        public event Action<float, float> OnHealthChanged;
        public void Construct(float health)
        {
            _maxHealth = health;
            Initializ();
        }

        private void Initializ()
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