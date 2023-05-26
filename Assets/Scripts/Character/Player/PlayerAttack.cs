using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Character.Player.Weapon;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerAttack : MonoBehaviour
    {

        [SerializeField] private PlayerWeapon _weapon;
        private EnemyHealth _target;
        private bool _inAttackArea;

        private void Update()
        {
            if (_target == null || !_inAttackArea) return;
            _weapon.Shoot(_target);
        }
        public void SetInAttackArea(bool inAttackArea) => 
            _inAttackArea = inAttackArea;
        public void SetHealthTarget(EnemyHealth target) =>
            _target = target;
    }
}