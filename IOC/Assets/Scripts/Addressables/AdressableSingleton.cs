using System;
using System.Collections;
using System.Collections.Generic;
using Addressables;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class AdressableSingleton<T> : MonoBehaviour where T : AdressableSingleton<T>
{
    private static bool _isLoad;
    private static bool inLoad;
    protected static string AdressableName= typeof(T).Name;
    
    public static async void Get(Action<T> callback)
    {
        if (!_isLoad)
        {
            if (!inLoad)
            {
                AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>(AdressableName, LoadInstance);
                inLoad = true;
            }
        }
        else
        { 
            callback.Invoke(_instance);
        }
        await UniTask.WaitUntil(() => _isLoad);
        callback.Invoke(_instance);
    }


    private static void LoadInstance(GameObject gameObject)
    {
        
        _instance = Object.Instantiate(gameObject).GetComponent<T>();
        _isLoad = true;
    }

    private static T _instance;
}