using System.Collections;
using System.Collections.Generic;
using Addressables;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AddressableSingleton<T> : MonoBehaviour where T : Component
{
    public static T instance;

    public async UniTask<T> GetInstance(string key = null)
    {
        if (instance != null) return instance;
        var task = UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<T>(key);
        await task;
        return task.Result;
    }
}