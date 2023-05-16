using ALAIIIIIIID;
using UnityEngine;
using UnityEngine.UI;

public class UI_Idle_Game : MonoBehaviour
{
    public IIdleGame_Service m_idleGameService;
    
    [SerializeField] Text textLumber;
    [SerializeField] Text textGold;
    [SerializeField] Text textTool;
    
    private void Start()
    {
        m_idleGameService.SetUiIdleGame(this);
    }
    //
    // private void InitService()
    // {
    //     m_idleGameService.InitService();
    // }

    public void SetLumber(int lumber)
    {
        textLumber.text = lumber.ToString();
    }
    
    public void SetRock(int gold)
    {
        textGold.text = gold.ToString();
    }
    
    public void SetCartePokemon(int tool)
    {
        textTool.text = tool.ToString();
    }
    
    public void SpawnLumberJack()
    {
        m_idleGameService.MakeLumberJack();
    }
    
    public void SpawnMinecrafter()
    {
        m_idleGameService.MakeMinecraft();
    }
    
    public void SpawnDavidLAFORGE()
    {
        m_idleGameService.MakeDavidLaforge();
    }
}
