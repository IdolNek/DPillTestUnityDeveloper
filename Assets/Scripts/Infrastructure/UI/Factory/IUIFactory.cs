using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateGameMenuWindow();
        void CreateUIRoot();
    }
}