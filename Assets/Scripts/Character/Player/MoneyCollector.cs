using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class MoneyCollector : MonoBehaviour
    {
        [SerializeField] private Transform _itemParentPoint;
        [SerializeField] private float _moneyOffset;
        private List<GameObject> _moneyBank = new List<GameObject>();
        private IProgressService _progressService;

        public void Construct(IProgressService progressService) => 
            _progressService = progressService;
        public void AddMoneyBank(GameObject money)
        {
            _moneyBank.Add(money);
            money.transform.SetParent(_itemParentPoint);
            money.transform.position = Vector3.zero;
            money.transform.position = Vector3.up * _moneyOffset * (_moneyBank.Count - 1);
        }

        public void RemoveAllMoney()
        {
            foreach (GameObject money in _moneyBank)
            {
                _progressService.Money.Collect(money.GetComponent<Money>().Count);
                Destroy(money);
            }
        }
    }

}