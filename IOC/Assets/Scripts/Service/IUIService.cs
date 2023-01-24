using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Service;
using UnityEngine;

namespace Service
{
    public interface IUIService : IService
    {
        public void LoadUI();

        public void ShowUIMainMenu();

        public void HideUIInGame();
    };
}
