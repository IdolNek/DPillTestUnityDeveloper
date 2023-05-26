using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class WeaponTarget : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private Death _death;
        private ChooseTarget _chooseTarget;
        private bool _isDied;

        public EnemyHealth Health => _health;

        private void Start() =>
            _death.CharacterDied += OnEnemyDied;

        private void Update()
        {
            if (_chooseTarget == null || _isDied) return;
            SetWeaponTarget();
        }

        public void SetWeapon(ChooseTarget chooseTarget) =>
            _chooseTarget = chooseTarget;

        private void OnEnemyDied()
        {
            _chooseTarget?.SetWeaponTarget(null);
            _isDied = true;
            _chooseTarget = null;
        }

        private void SetWeaponTarget()
        {
            if (_chooseTarget.Target == null) _chooseTarget.SetWeaponTarget(this);
            var weaponDistance = Vector3.Distance(_chooseTarget.GetWeaponPosition(), transform.position);
            if (weaponDistance < _chooseTarget.GetTargetDistance()) _chooseTarget.SetWeaponTarget(this);
        }
        private void OnEnable()
        {
            _isDied = false;
            _death.CharacterDied += OnEnemyDied;
        }
        private void OnDisable()
        {
            _isDied = true;
            _death.CharacterDied -= OnEnemyDied;
        }

        public void NotTarget()
        {
            _chooseTarget.SetWeaponTarget(null);
            _chooseTarget = null;
        }
    }
}