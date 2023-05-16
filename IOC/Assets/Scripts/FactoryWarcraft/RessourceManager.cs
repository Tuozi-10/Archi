
public class RessourceManager
{
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
    }
    
    public void AddRock(int nb)
    {
        m_rock += nb;
    }
    
    public void AddTool(int nb)
    {
        m_tool += nb;
    }
    
    public void GetRessourceToTool()
    {
        m_lumber -= 20;
        m_rock -= 20;
    }
    
    public bool EnoughToTool()
    {
        return m_lumber >= 20 && m_rock >= 20;
    }
}
