using Addressables;
using Attributes;
using Service.UIService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service.PopUpService
{
    public class PopUpService : IPopUpService
    {
        [DependsOnService]
        private IUIService uiService;

        private UIPopup popup;
        
        public void LoadPopUp()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("PopUp", CreatePopUp);
        }

        private void CreatePopUp(GameObject asset)
        {
            popup = Object.Instantiate(asset,uiService.updateCanvas).GetComponent<UIPopup>();
            popup.GetComponent<RectTransform>().localPosition = Vector3.zero;

            popup.ClearContent();
            RegisterPopUp("un","un");
            RegisterPopUp("deux","deux");
            RegisterPopUp("trois","trois");
            RegisterPopUp("quatre","quatre");
            popup.NextContent();

            Release(asset);
        }
    
        public void RegisterPopUp(string text, string header)
        {
            popup.AddContent(text, header);
        }
    }
}


