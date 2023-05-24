using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class OpenGameMenu : MonoBehaviour
    {
        [SerializeField] private WindowsId _windowID;
        [SerializeField] private Button _buttonMenu;
        private IWindowsService _windowsService;

        public void Construct(IWindowsService windowService) => 
            _windowsService = windowService;
        private void Awake() => 
            _buttonMenu.onClick.AddListener(Open);

        private void Open() => 
            _windowsService.Open(_windowID);
    }
}