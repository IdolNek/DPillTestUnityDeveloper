using PlayerProgress;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public LootData Loot { get; set; }

        public PersistentProgressService()
        {
            Loot = new LootData();
        }
    }
}