using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Windows;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        private IWindowsService _windowsService;

        public void Construct(IWindowsService windowsService) => 
            _windowsService = windowsService;
        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(float currentHP, float maxHP)
        {
            if (currentHP <= 0) Died();
        }

        private void Died() => 
            _windowsService.Open(WindowsId.GameMenu);
    }
}