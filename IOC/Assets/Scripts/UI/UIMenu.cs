using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMenu : MonoBehaviour
    {
        public Button playButton;
        public Button exitButton;
        public RectTransform sidePanel;
        
        private void Start()
        {
            playButton.onClick.AddListener(MovePanelIn);
            exitButton.onClick.AddListener(MovePanelOut);
        }

        private void MovePanelIn()
        {
            //playButton.transform.DOKill();
            //playButton.transform.DOScale(0.01f,0.25f).SetEase(Ease.InBack);

            sidePanel.DOKill();
            sidePanel.DOLocalMoveX(sidePanel.sizeDelta.x, 1f).SetEase(Ease.OutBack);
        }
        
        private void MovePanelOut()
        {
            //playButton.transform.DOKill();
            //playButton.transform.DOScale(1,0.25f).SetEase(Ease.InBack);

            sidePanel.DOKill();
            sidePanel.DOLocalMoveX(2*sidePanel.sizeDelta.x,1f).SetEase(Ease.InBack);
        }
    }
}
