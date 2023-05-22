using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.UI.Factory;

namespace Assets.Scripts.Infrastructure.Services.Windows
{
    public class WindowsService : IWindowsService
    {
        private readonly IUIFactory _uiFactory;

        public WindowsService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowsId windowsId)
        {
            switch (windowsId)
            {
                case WindowsId.None:
                    break;
                case WindowsId.GameMenu:
                    break;
            }
        }
    }
}