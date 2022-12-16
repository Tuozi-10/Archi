using Service.UIService;
using UnityEngine;

namespace UI
{
    public class InGameCanvas : MonoBehaviour
    {
        private IUIService m_uiService;
    
        public void AssignService(IUIService service)
        {
            m_uiService = service;
            SetReference();
        }

        private void SetReference()
        {
            m_uiService.SetInGameCanvas(gameObject);
        }

        public void OnToggle(bool b)
        {
            m_uiService.Toggle(b);
        }
    }
}
