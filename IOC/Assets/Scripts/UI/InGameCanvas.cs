using DG.Tweening;
using Service.UIService;
using UnityEngine;

namespace UI
{
    public class InGameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPlay;
        [SerializeField] private GameObject buttonOption;
        [SerializeField] private GameObject buttonBarreLat;
        [SerializeField] private GameObject buttonBarreLat2;
        [SerializeField] private RectTransform barreLat;
        private bool barreLatOut;
        
        private GameObject mainMenu;
        private bool isLoading;

        public void AssignService(IUIService service)
        {
            SetReference();
        }
        
        private void SetReference()
        {
            
        }

        public void OnToggle(bool b)
        {
        }

        public void BarreLat()
        {
            barreLat.transform.DOKill();
            barreLatOut = !barreLatOut;
            if (barreLatOut)
            {
                barreLat.DOAnchorPos(new Vector2(0, 0), 0.5f);
                buttonBarreLat.SetActive(false);
                buttonBarreLat2.SetActive(true);
            }
            else
            {
                barreLat.DOAnchorPos(new(-500, 0), 0.5f);
                buttonBarreLat2.SetActive(false);
                buttonBarreLat.SetActive(true);
            }
        }
    }
}
