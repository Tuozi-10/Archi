using System;
using System.Collections;
using System.Collections.Generic;
using HelperPSR.Logs;
using UnityEngine;

public class PackageUtilitiesTester : MonoBehaviour
{
    private void Awake()
    {
       Logs.Log("test utilities tester", LogType.Log, Logs.LogColors.Blue);
    }
}
