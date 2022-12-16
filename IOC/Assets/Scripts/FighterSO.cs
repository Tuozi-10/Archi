using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSO : MonoBehaviour
{
    public FighterData fighterData;
    public string addressPrefabName;
    Fighter GetFighter()
    {
        return new Fighter(fighterData);
    }
}
