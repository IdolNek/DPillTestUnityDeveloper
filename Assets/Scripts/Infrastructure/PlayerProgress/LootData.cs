using System;

namespace PlayerProgress
{
    public class LootData
    {
        private float _collected;
        
        public float Collected => _collected;
        public event Action OnLootChanged;

        public void Collect(float loot)
        {
            _collected += loot;
            OnLootChanged?.Invoke();
        }  
    }
}