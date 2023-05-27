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
        [SerializeField]
        private List<GameObject> _moneyBank = new List<GameObject>();
        private IProgressService _progressService;

        public void Construct(IProgressService progressService) =>
            _progressService = progressService;
        public void AddMoneyBank(GameObject money)
        {
            _moneyBank.Add(money);
            money.transform.SetParent(_itemParentPoint);
            for (int i = 0; i < _moneyBank.Count; i++)
            {
                GameObject item = _moneyBank[i];
                item.transform.localPosition = Vector3.zero;
                item.transform.localEulerAngles = new Vector3(0, 90, 0);
                item.transform.localPosition = Vector3.up * _moneyOffset * i;
            }
        }

        public void RemoveAllMoney()
        {
            foreach (GameObject money in _moneyBank)
            {
                _progressService.Money.Collect(money.GetComponent<Money>().Count);
            }
            ResetMoneyBank();
        }

        public void ResetMoneyBank()
        {
            foreach (var item in _moneyBank)
            {
                Destroy(item);
            }
            _moneyBank = new List<GameObject>();
        }
    }

}