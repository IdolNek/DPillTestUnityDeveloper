using Assets.Scripts.Character.Enemy;
using UnityEngine;

namespace Assets.Scripts.Character.Player.Weapon
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private BulletSpawner _bulletSpawner;
        private float _reloadTime;
        private float _currentReloadTime;
        private bool _isReloded = true;

        public void Initialize(float attackCountDown) =>
            _reloadTime = attackCountDown;
        private void Update()
        {
            _currentReloadTime -= Time.deltaTime;
            if (_currentReloadTime < 0) _isReloded = true;
        }

        public void Shoot(EnemyHealth target)
        {
            if (!_isReloded) return;
            _currentReloadTime = _reloadTime;
            _bulletSpawner.Spawn(target);
            _isReloded = false;
        }
    }
}