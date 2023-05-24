using UnityEngine;

namespace Assets.Scripts.Character.CharacterUI
{
    public class UIMonitor : MonoBehaviour
    {
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Health _health;
        private void Start() => 
            _health.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged(float currentHP, float maxHP) => 
            _healthBar.SetValue(currentHP, maxHP);
    }
}