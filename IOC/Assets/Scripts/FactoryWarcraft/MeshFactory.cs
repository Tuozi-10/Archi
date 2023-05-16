using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFactory
{
    GameObject PeonPrefab = null;
    GameObject newMinion = null;

    public MeshFactory(GameObject meshPrefab)
    {
        PeonPrefab = meshPrefab;
    }

    public GameObject GenerateMinion()
    {
        newMinion = Object.Instantiate(PeonPrefab);
        newMinion.transform.position = Vector3.zero;
        
        return newMinion;
    }
}