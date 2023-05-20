namespace Assets.Scripts.Infrastructure.GameFactory
{
    public class GameFactory : IGameFactory
    {

        //private GameObject HeroGameObject { get; set; }
        //private readonly IAsset _asset;
        //private readonly IStaticDataService _staticData;
        //private readonly IPersistentProgressService _persistentProgress;
        //private readonly IWindowService _windowService;

        //public GameFactory(IAsset asset, IStaticDataService staticData,
        //    IPersistentProgressService persistentProgress, IWindowService windowService)
        //{
        //    _asset = asset;
        //    _staticData = staticData;
        //    _persistentProgress = persistentProgress;
        //    _windowService = windowService;
        //}

        //public void WarmUp()
        //{
        //}

        //public GameObject CreateHero(Vector3 at)
        //{
        //    HeroGameObject = InstantiateRegistered(AssetAdress.HeroPath, at);
        //    return HeroGameObject;
        //}

        //public GameObject CreateHud()
        //{
        //    GameObject hud = InstantiateRegistered(AssetAdress.HUDPath);
        //    hud.GetComponent<LootCounter>().Construct(_persistentProgress.PlayerProgress.WorldData);
        //    foreach (OpenWindowButton openWindow in hud.GetComponentsInChildren<OpenWindowButton>())
        //        openWindow.Construct(_windowService);
        //    return hud;
        //}

        //public LootPiece CreateLoot()
        //{
        //    LootPiece lootPiece = InstantiateRegistered(AssetAdress.LootPath).GetComponent<LootPiece>();
        //    lootPiece.Construct(_persistentProgress.PlayerProgress.WorldData);
        //    return lootPiece;
        //}

        //public void CreateSpawner(Vector3 at, string spawnerId, MonsterTypeID monsterTypeID)
        //{
        //    var spawner = InstantiateRegistered(AssetAdress.SpawnerPath, at).GetComponent<SpawnPoint>();
        //    spawner.Construct(this);
        //    spawner.Id = spawnerId;
        //    spawner.MonsterTypeID = monsterTypeID;
        //}
    }
}