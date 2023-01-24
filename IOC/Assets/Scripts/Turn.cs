using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
public static Turn instance;

private void Awake()
{
    if (!instance)
        Destroy(this);
    else
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
}
}
