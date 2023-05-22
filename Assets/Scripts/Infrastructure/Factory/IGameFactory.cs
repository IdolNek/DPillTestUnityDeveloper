using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        //void CreateSpawner(Vector3 at, string spawnerId, MonsterTypeID monsterTypeID);
        //LootPiece CreateLoot();
    }
}