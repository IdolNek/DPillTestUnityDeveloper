using Assets.Scripts.Character.Enemy;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class ChooseTarget : MonoBehaviour
    {

        [SerializeField] private PlayerAttack _attack;
        private WeaponTarget _target;
        public WeaponTarget Target => _target;

        public void SetWeaponTarget(WeaponTarget target)
        {
            _target = target;
            if (_target == null) _attack.SetHealthTarget(null);
            else _attack.SetHealthTarget(_target.Health);
        }

        public float GetTargetDistance() =>
            Vector3.Distance(_target.transform.position, transform.position);

        public Vector3 GetWeaponPosition() =>
            transform.position;
    }
}