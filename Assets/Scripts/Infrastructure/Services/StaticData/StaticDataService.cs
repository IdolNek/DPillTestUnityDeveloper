using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string staticDataEnemies = "GameOption/EnemyData";
        private const string staticDataLevels = "GameOption/LevelData";
        private const string staticDataWindows = "GameOption/WindowsData/WindowsData";
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemys;
        private Dictionary<EnemyTypeId, EnemySpawnStaticData> _enemysSpawns;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowsId, WindowConfig> _windowConfigs;

        public void LoadStaticData()
        {
            _enemys = Resources.LoadAll<EnemyStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _enemysSpawns = Resources.LoadAll<EnemySpawnStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _levels = Resources
                .LoadAll<LevelStaticData>(staticDataLevels)
                .ToDictionary(x => x.LevelKey, x => x);
            _windowConfigs = Resources
                .Load<WindowsStaticData>(staticDataWindows)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) =>
            _enemys.TryGetValue(typeId, out EnemyStaticData staticData)
                ? staticData
                : null;
        public EnemySpawnStaticData ForSpawn(EnemyTypeId typeId) =>
            _enemysSpawns.TryGetValue(typeId, out EnemySpawnStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string levelKey) =>
            _levels.TryGetValue(levelKey, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowConfig ForWindow(WindowsId windowsId) =>
            _windowConfigs.TryGetValue(windowsId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}