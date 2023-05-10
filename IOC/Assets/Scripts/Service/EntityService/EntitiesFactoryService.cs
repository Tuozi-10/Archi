using System;
using Service;
using UnityEngine;

namespace Service
{
    public class EntitiesFactoryService : IEntitiesFactoryService
    {
        public void EnabledService(Action callback = null)
        {
            throw new NotImplementedException();
        }

        public void DisabledService(Action callback = null)
        {
            throw new NotImplementedException();
        }

        public bool GetIsActiveService { get; }
    }
}