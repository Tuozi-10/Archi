using Addressables;
using Attributes;
using UnityEngine;

namespace Service.UIService
{
    public class UIService : SwitchableService, IUIService
    {
    private GameObject guiCanvas;

    [ServiceInit]
    private void Initialize() { }

    public override void Enable()
    {
        guiCanvas.SetActive(true);
    }

    public override void Disable()
    {
        guiCanvas.SetActive(false);
    }

    public void SetInGameCanvas(GameObject g)
    {
        guiCanvas = g;
    }
    }
}
