using System;
using System.Collections;
using System.Collections.Generic;
using PlasticGui.WorkspaceWindow;
using UnityEngine;

namespace Service
{
    public interface ISwitchableService : IService
    {
     
        void EnabledService(Action callback = null);
        void DisabledService(Action callback = null);

        bool GetIsActiveService
        {
            get;
        }
    }
}