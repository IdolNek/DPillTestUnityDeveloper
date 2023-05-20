using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public Vector3 InitialHeroPosition;
    }
}