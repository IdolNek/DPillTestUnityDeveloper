using PlayerProgress;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        LootData Loot { get; set; }
    }
}