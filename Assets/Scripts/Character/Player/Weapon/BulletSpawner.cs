using Assets.Scripts.Character.Enemy;
using Assets.Scripts.SpawnPool;
using UnityEngine;

namespace Assets.Scripts.Character.Player.Weapon
{
    public class BulletSpawner : BulletPool
    {
        public void Spawn(EnemyHealth target)
        {
            if (TryGetObject(out GameObject bullet))
            {
                bullet.transform.position = transform.position;
                bullet.transform.LookAt(target.transform.position + new Vector3(0f, 0.5f, 0f));
                bullet.SetActive(true);
            }
        }
    }
}