using System.Collections.Generic;
using Addressables;
using Attributes;
using Service;
using Service.AudioService;
using Service.FightService;
using Service.SceneService;
using Service.UIService;
using UI;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

public class FightService : SwitchableService, IFightService
{
    public List<GameObject> entities = new List<GameObject>();

    [ServiceInit]
    private void Initialize() { }

    void GenerateEntity(GameObject go)
    {
        var obj = Object.Instantiate(go);
        
        obj.SetActive(isActive);
        
        var pos = Random.insideUnitSphere * 15;
        pos.y = 1;
        obj.transform.position = pos;
        
        entities.Add(obj);
        
        obj.GetComponent<EntityData>().Initialization();

        Release(go);
    }
    
    public override void Enable()
    {
        base.Enable();
        foreach (var ent in entities)
        {
            ent.SetActive(true);
        }
    }

    public override void Disable()
    {
        base.Disable();
        foreach (var ent in entities)
        {
            ent.SetActive(false);
        }
    }

    public void CreateFighter()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Entity", GenerateEntity);
    }

    public void RotateFighter()
    {
        foreach (var ent in entities)
        {
            if (!ent) continue;
            ent.transform.Rotate(Vector3.up);
        }
    }
}