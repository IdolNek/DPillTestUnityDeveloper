using Infrastructure.StaticData.WindowsData;

namespace Assets.Scripts.Infrastructure.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowsId windowsId);
    }
}