using UnityEngine;

public class PopUpComponent : MonoBehaviour
{
    private UIDebug uiDebug;
    private void Awake()
    {
        uiDebug = GetComponentInParent<UIDebug>();
    }

    public void HideButton()
    {
        uiDebug.HidePopUp();
    }
}
