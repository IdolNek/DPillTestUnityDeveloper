using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateGameMenuWindow();
        void CreateUIRoot();
        void Initialize(GameFactory gameFactory);
    }
}