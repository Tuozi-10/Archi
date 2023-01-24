using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpData 
{
    public string title;
    public string description;
    public Color colorBackground;

    public PopUpData(string title, string description, Color colorBackground )
    {
        this.title = title;
        this.description = description;
        this.colorBackground = colorBackground;

    }
}
