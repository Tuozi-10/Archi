using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;
    public PopUpData data;
    private MainMenuManager manager;

    public void OnCancel()
    {
        manager.OnNextPopUpClick();   
    }
    
    public void SetText(MainMenuManager manager)
    {
        this.manager = manager;
        text.text = data.message;
        image.color = data.color;
    }

    public struct PopUpData
    {
        public string message;
        public Color color;
    }
}
