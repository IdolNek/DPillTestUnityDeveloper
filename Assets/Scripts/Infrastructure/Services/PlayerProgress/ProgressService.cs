using Assets.Scripts.MoneyBank;

namespace Assets.Scripts.Infrastructure.Services.PlayerProgress
{
    public class ProgressService : IProgressService
    {
        public MoneyData Money { get; set; }

        public ProgressService()
        {
            Money = new MoneyData();
        }
    }
}