using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _harvesterButton;
        [SerializeField] private Button _lumberjackButton;

        public void Setup(IEntitiesFactoryService entityFactoryService)
        {
            _harvesterButton.onClick.AddListener(() => entityFactoryService.CreateHarvester());
            _lumberjackButton.onClick.AddListener(() => entityFactoryService.CreateLumberjack());
        }
    }
}