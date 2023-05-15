using System;
using System.Collections;
using System.Collections.Generic;
using Attributes;
using ALAIIIIIIID;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Idle_Game : MonoBehaviour
{
    [DependsOnService] private IdleGame_Service m_idleGameService;
    
    [SerializeField] Text textLumber;
    [SerializeField] Text textGold;
    [SerializeField] Text textTool;
    private void Awake()
    {
        Debug.Log("UI_Idle_Game Start");
        InitService();
    }

    private void InitService()
    {
        m_idleGameService.InitService();
    }

    public void SetLumber(int lumber)
    {
        textLumber.text = lumber.ToString();
    }
    
    public void SetGold(int gold)
    {
        textGold.text = gold.ToString();
    }
    
    public void SetTool(int tool)
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
