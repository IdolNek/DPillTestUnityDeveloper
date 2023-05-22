using System;

namespace PlayerProgress
{
    public class MoneyData
    {
        private float _collected;
        
        public float Collected => _collected;
        public event Action OnLootChanged;

        public void Collect(float money)
        {
            _collected += money;
            OnLootChanged?.Invoke();
        }  
    }
}