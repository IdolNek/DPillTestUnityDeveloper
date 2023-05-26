using Assets.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class MoneySpawn : MonoBehaviour
    {
        [SerializeField] private Death _death;

        private IGameFactory _gameFactory;
        private int _moneyCount;

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Initialize(int moneyCount) => 
            _moneyCount = moneyCount;

        private void OnEnable() => 
            _death.CharacterDied += OnCharacterDied;

        private void OnCharacterDied()
        {
            var money = _gameFactory.CreateMoney(transform.position);
            money.GetComponent<Money>().SetCount(_moneyCount);
        }

        private void OnDisable() => 
            _death.CharacterDied -= OnCharacterDied;

    }
}