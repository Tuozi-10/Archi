using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Popup", menuName = "PopUpSO")]
public class PopUpSO : ScriptableObject
{
    public Sprite image;
    public string title;
    public string description;
}
