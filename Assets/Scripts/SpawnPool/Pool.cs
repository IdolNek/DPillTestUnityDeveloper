using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public abstract class Pool : MonoBehaviour, IPool
    {
        private readonly List<GameObject> _pool = new List<GameObject>();

        public List<GameObject> GameObjPool => _pool;

        private protected void AddToPool(GameObject poolItem)
        {
            _pool.Add(poolItem);
            poolItem.SetActive(false);

        }
        private protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }
        abstract protected void InitializePool();
    }
}
