using System.Collections;
using System.Collections.Generic;
using Addressables;
using Attributes;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Utilities.Extentions;

public class FightService : TickableSwitachable, IFightService
{
    private GameObject burger;
    private GameObject perso;
    private Perso m_perso;
    
    private List<Perso> m_persos = new List<Perso>();
    private SOEntity _soEntity;

    [ServiceInit]
    private void Initialize()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LeBurger",GenerateBurger);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<SOEntity>("alaiiid",GeneratePerso);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("LePerso",GeneratePerso);
    }

    private void GeneratePerso(SOEntity obj)
    {
        _soEntity = obj;
        foreach (var perso in m_persos)
        {
            perso.SetSO(obj);
        }
    }

    private void GeneratePerso(GameObject obj)
    {
        perso = Object.Instantiate(obj);
        m_persos.Add(perso.GetComponent<Perso>());
        Enable();

        if (_soEntity != null)
        {
            perso.GetComponent<Perso>().SetSO(_soEntity);
        }
    }


    public override void Disable()
    {
        base.Disable();
        if (burger != null)
        {
            burger.SetActive(false);
        }
    }

    public override void Enable()
    {
        base.Enable();
        if(burger != null)
        {
            burger.SetActive(true);
        }
    }

    private void GenerateBurger(GameObject burgerTemp)
    {
        burger = Object.Instantiate(burgerTemp);
        Enable();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (burger != null)
        {
            burger.transform.AddRotaX(1);
            burger.transform.AddRotaY(1);
        }
    }
}
