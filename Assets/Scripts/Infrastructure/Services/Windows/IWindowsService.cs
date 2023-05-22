using Assets.Scripts.Infrastructure.GameOption.WindowsData;

namespace Assets.Scripts.Infrastructure.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowsId windowsId);
    }
}