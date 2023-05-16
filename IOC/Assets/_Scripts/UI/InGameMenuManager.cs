using Service;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _harvesterButton;
        [SerializeField] private Button _lumberjackButton;

        public void Setup(IEventService eventService)
        {
            _harvesterButton.onClick.AddListener(() => eventService.Trigger(new CreateEvent(TypeWorker.HARVESTER)));
            _lumberjackButton.onClick.AddListener(() => eventService.Trigger(new CreateEvent(TypeWorker.LUMBERJACK)));
        }
    }
}