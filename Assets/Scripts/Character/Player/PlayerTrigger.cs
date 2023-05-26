using Assets.Scripts.Character.Enemy;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerTrigger : MonoBehaviour
    {

        [SerializeField] private SphereCollider _sphereCollider;
        [SerializeField] private ChooseTarget _chooseTarget;

        public void Initialize(float attackRange) =>
            _sphereCollider.radius = attackRange;

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<WeaponTarget>(out WeaponTarget enemy))
            {
                enemy.SetWeapon(_chooseTarget);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<WeaponTarget>(out WeaponTarget enemy))
            {
                enemy.NotTarget();
            }
        }
    }
}