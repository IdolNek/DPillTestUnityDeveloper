using System;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        public event Action CharacterDied;

        private void OnEnable() =>
            _health.OnHealthChanged += OnHealthChanged;
        private void OnHealthChanged(float hP, float maxHP)
        {
            if (hP <= 0) Die();
        }

        private void Die()
        {
            CharacterDied?.Invoke();
            gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }

    }
}