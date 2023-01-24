using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI textText;
    [SerializeField] private Button closeButton;
    
    public class Content
    {
        public string header { get; private set; }
        public string text { get; private set; }

        public Content(string text, string header)
        {
            this.text = text;
            this.header = header;
        }
    }

    public Queue<Content> popUpQueue = new Queue<Content>();

    private void Start()
    {
        closeButton.onClick.AddListener(NextContent);
    }

    public void ClearContent()
    {
        popUpQueue.Clear();
    }

    public void AddContent(string text, string header)
    {
        popUpQueue.Enqueue(new Content(text,header));
    }

    public void NextContent()
    {
        if (!popUpQueue.TryDequeue(out var result))
        {
            mainPanel.SetActive(false);
            return;
        }
        
        mainPanel.SetActive(true);

        headerText.text = result.header;
        textText.text = result.text;
    }
}
