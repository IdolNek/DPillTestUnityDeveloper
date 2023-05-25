using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class GenerateRandomPointInAttackArea : MonoBehaviour
    {
        private Vector3 _centerAreaSpawn;
        private Vector3 _sizeAreaSpawn;

        public void Construct(Vector3 centerAreaSpawn, Vector3 sizeAreaSpawn)
        {
            _centerAreaSpawn = centerAreaSpawn;
            _sizeAreaSpawn = sizeAreaSpawn;
        }

        public Vector3 GetRandomPointInAttackArea()
        {
            float minX = _centerAreaSpawn.x - (_sizeAreaSpawn.x / 2);
            float maxX = _centerAreaSpawn.x + (_sizeAreaSpawn.x / 2);
            float xRange = Random.Range(minX, maxX);
            float minZ = _centerAreaSpawn.z - (_sizeAreaSpawn.z / 2); ;
            float maxZ = _centerAreaSpawn.z + (_sizeAreaSpawn.z / 2); ;
            float yRange = Random.Range(minZ, maxZ); ;
            const float ground = 0.1f;
            return new Vector3(xRange, ground, yRange);
        }

    }
}