using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Warcraft : MonoBehaviour
{
    public Button btnPeon;
    public Button btnPeonMiner;
    public Button btnPeonBlacksmith;
    
    [SerializeField] Text m_textLumber;
    [SerializeField] Text m_textGold;
    [SerializeField] Text m_textTool;

    public void SetLumber(int lumber)
    {
        m_textLumber.text = lumber.ToString();
    }
    
    public void SetGold(int gold)
    {
        m_textGold.text = gold.ToString();
    }
    
    public void SetTool(int tool)
    {
        m_textTool.text = tool.ToString();
    }
}
