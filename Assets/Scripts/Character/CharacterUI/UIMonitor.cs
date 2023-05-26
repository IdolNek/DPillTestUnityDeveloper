using UnityEngine;

namespace Assets.Scripts.Character.CharacterUI
{
    public class UIMonitor : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Health _health;

        private void OnEnable() => 
            _health.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged(float currentHP, float maxHP) => 
            _healthBar.SetValue(currentHP, maxHP);
        private void OnDisable() => 
            _health.OnHealthChanged -= OnHealthChanged;
    }
}