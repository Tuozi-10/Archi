using System.Collections.Generic;
using Addressables;
using Attributes;
using TMPro;
using UnityEngine;

namespace Service
{
    public class UIService : IUIService
    {
        private GameObject mainMenu;
        private bool isLoading;
       
        private Transform uiMenu;

      [ServiceInit]
        public void DisplayMainMenu()
        {
            if(isLoading) return;
            if(mainMenu != null) mainMenu.SetActive(true);
            else
            {
                AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("UIMenu",GenerateUIMenu);
            }
            
        }

        private void GenerateUIMenu(GameObject gameObject)
        {
            var uiMenu = Object.Instantiate(gameObject);
            this.uiMenu = uiMenu.transform;
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("PopUp", LoadPopUpGeneric);
        }

        private void LoadPopUpGeneric(GameObject gameObject)
        {
            var popUp = Object.Instantiate(gameObject, uiMenu);
            uiMenu.GetComponent<UIDebug>().popUpObj = popUp;
            uiMenu.GetComponent<UIDebug>().popUpText = popUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

       
    }
}

