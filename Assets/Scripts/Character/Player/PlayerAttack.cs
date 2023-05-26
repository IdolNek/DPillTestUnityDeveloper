using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Character.Player.Weapon;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerAttack : MonoBehaviour
    {

        [SerializeField] private PlayerWeapon _weapon;
        private EnemyHealth _target;

        private void Update()
        {
            if (_target == null) return;
            _weapon.Shoot(_target);
        }

        public void SetHealthTarget(EnemyHealth target) =>
            _target = target;
    }
}