using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class UIDebug : MonoSingleton<UIDebug>
{
    private Queue<string> popUpQueue;
    [HideInInspector] public GameObject popUpObj;
    [HideInInspector] public TextMeshProUGUI popUpText;
    private void Start()
    {
        popUpQueue = new Queue<string>();
    }

    public void HidePopUp()
    {
        if(popUpQueue.Count <= 0)
        {
            popUpObj.SetActive(false);
            return;
        }
        
        popUpQueue.Dequeue();
        popUpText.text = popUpQueue.Peek();
        
        if(popUpQueue.Count <= 0) popUpObj.SetActive(false);
    }

    public void AddMessageToPopUpQueue(string text)
    {
        popUpQueue.Enqueue(text);
        popUpText.text = popUpQueue.Peek();
        popUpObj.SetActive(true);
    }
    
    [Conditional("DEBUG")]
    public void DrawDebugMessage(string text)
    {
        Logs.Log("UI DEBUG", text, LogType.Log, Logs.LogColor.Green, Logs.LogColor.None);
    }
}
