using Assets.Scripts.Infrastructure.StaticData.EnemyData;
using Assets.Scripts.Infrastructure.StaticData.LevelData;
using Infrastructure.StaticData.WindowsData;


namespace Assets.Scripts.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadStaticData();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        LevelStaticData ForLevel(string levelKey);
        WindowConfig ForWindow(WindowsId chooseAbility);
    }
}