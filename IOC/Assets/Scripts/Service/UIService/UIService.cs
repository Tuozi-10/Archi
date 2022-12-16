using Addressables;
using Attributes;
using UnityEngine;

namespace Service.UIService
{
    public class UIService : IUIService
    {
        private GameObject guiCanvas;
        
        [ServiceInit]
        private void Initialize()
        {
            
        }
        
        public void Toggle(bool active)
        {
            if (active)
            {
                Enable();
                return;
            }
            Disable();
        }

        public void Enable()
        {
            guiCanvas.SetActive(true);
        }

        public void Disable()
        {
            guiCanvas.SetActive(false);
        }

        public void SetInGameCanvas(GameObject g)
        {
            guiCanvas = g;
        }
    }
}
