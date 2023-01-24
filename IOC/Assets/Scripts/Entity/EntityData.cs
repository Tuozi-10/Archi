using System.Collections;
using System.Collections.Generic;
using Addressables;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    public int health;
    public int damage;

    public void Initialization()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("Entity01", GenerateEntityData);
    }

    private void GenerateEntityData(EntitySO data)
    {
        health = data.health;
        damage = data.damage;
    }
}
