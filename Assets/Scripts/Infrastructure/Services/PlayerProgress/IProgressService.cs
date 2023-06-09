﻿using Assets.Scripts.MoneyBank;

namespace Assets.Scripts.Infrastructure.Services.PlayerProgress
{
    public interface IProgressService : IService
    {
        MoneyData Money { get; set; }
    }
}