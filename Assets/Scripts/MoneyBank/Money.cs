using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class Money : MonoBehaviour
    {
        [SerializeField]
        private int _count;

        public int Count => _count;

        public void SetCount(int count) => 
            _count = count;
    }
}