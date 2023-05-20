﻿using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.UIFactory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        void CreateUIRoot();
    }
}