using System.Collections.Generic;
using Addressables;
using Attributes;
using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace Service
{
    public class UIService : IUIService
    {
        private GameObject mainMenu;
        private HUDAssigner hud;
        private bool isLoading;
        
        private Transform uiMenu;

        [DependsOnService] private IEntitiesFactoryService entitiesFactoryService;
        

      [ServiceInit] public void Init()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("HUD", GenerateHUD);
        }

        private void GenerateHUD(GameObject obj)
        {
            var hudObj = Object.Instantiate(obj);
            hud = hudObj.GetComponent<HUDAssigner>();
            
            hud.AssignHarvesterButton(entitiesFactoryService.CreateHarvester);
            hud.AssignLumberjackButton(entitiesFactoryService.CreateLumberjack);
            hud.AssignBlacksmithButton(entitiesFactoryService.CreateBlacksmith);
        }

        public void UpdateResourcesUI(ResourcesSO so, int count)
        {
            switch (so.resourceName)
            {
                case "Wood": hud.UpdateWoodText($"{count}"); break;
                case "Stone" : hud.UpdateStoneText($"{count}"); break;
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

