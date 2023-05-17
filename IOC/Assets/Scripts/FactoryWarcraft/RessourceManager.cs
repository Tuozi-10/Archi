
using System;

public class RessourceManager
{
    public Action<int> OnLumberUpdate;
    public Action<int> OnRockUpdate;
    public Action<int> OnToolUpdate;
    
    private int m_lumber = 0;
    private int m_rock = 0;
    private int m_tool = 0;
    
    public RessourceManager()
    {
        m_lumber = 0;
        m_rock = 0;
        m_tool = 0;
    }
    
    public void AddWood(int nb)
    {
        m_lumber += nb;
        OnLumberUpdate?.Invoke(m_lumber);
    }
    
    public void AddRock(int nb)
    {
        m_rock += nb;
        OnRockUpdate?.Invoke(m_rock);
    }
    
    public void AddTool(int nb)
    {
        m_tool += nb;
        OnToolUpdate?.Invoke(m_tool);
    }
    
    public void GetRessourceToTool()
    {
        m_lumber -= 20;
        m_rock -= 20;
        OnLumberUpdate?.Invoke(m_lumber);
        OnRockUpdate?.Invoke(m_rock);
    }
    
    public bool EnoughToTool()
    {
        return m_lumber >= 20 && m_rock >= 20;
    }
}
