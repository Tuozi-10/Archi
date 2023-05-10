using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Service;
using UnityEngine;

namespace Service
{
public interface IBuildingFactoryService : IEntitiesFactoryService
{
    public Entity CreateHub(Vector3 pos);



    public Entity CreateForge(Vector3 pos);


    public Entity CreateStock(Vector3 pos);

}
    
}
