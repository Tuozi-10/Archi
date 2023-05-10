using System;
using UnityEngine;

public class SceneReferenceHolder : MonoBehaviour
{
    public static SceneReferenceHolder instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform hub, wood, stone, forge, stock;
    public int woodLoadDuration, stoneLoadDuration;
}
