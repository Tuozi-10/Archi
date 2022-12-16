using Attributes;
using Service;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Button buttonHide;
    
    [DependsOnService]
    private ISceneService m_sceneService;
    [DependsOnService]
    private IFightService m_fightService;
    
    public void Setup(ISceneService sceneService, IFightService fightService)
    {
        m_sceneService = sceneService;
        button.onClick.AddListener(() => m_sceneService.LoadScene("SecondScene"));
        m_fightService = fightService;
        buttonHide.onClick.AddListener(() => m_fightService.Toggle());
    }
}
