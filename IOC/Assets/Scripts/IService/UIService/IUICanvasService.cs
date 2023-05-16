using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service
{
public interface  IUICanvasService : IService
{
    void LoadMainMenu();

    void LoadPopUpCanvas();

    void LoadInGameMenu(Action callback);

}
    
}
