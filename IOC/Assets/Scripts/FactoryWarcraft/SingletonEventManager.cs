using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using UnityEngine;

public class SingletonEventManager : MonoBehaviour
{
    private static SingletonEventManager instance;

    public static bool AlreadyLoaded = false;

    static List<Func<bool>> FunctionPTR = new ();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void OnCreateInstance(GameObject obj)
    {
        Instantiate(obj);
        foreach (var func in FunctionPTR)
        {
            func();
        }
        FunctionPTR.Clear();
    }

    private static void TestNoInstance()
    {
        if (!AlreadyLoaded)
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("SingletonEvent", OnCreateInstance);
        AlreadyLoaded = true;
    }

    public static bool PrintPomme()
    {
        if (!instance)
        {
            TestNoInstance();
            FunctionPTR.Add(PrintPomme);
        }
        else
            Debug.Log("Pomme");

        return true;
    }

    public static bool PrintPoire()
    {
        if (!instance)
        {
            TestNoInstance();
            FunctionPTR.Add(PrintPoire);
        }
        else
            Debug.Log("Pomme");

        return true;
    }

    public static bool PrintYoupi()
    {
        if (!instance)
        {
            TestNoInstance();
            FunctionPTR.Add(PrintPoire);
        }
        else
            Debug.Log("Youpi");

        return true;
    }

    private void Start()
    {
        Debug.Log("SingletonEventManager Start");
    }
}