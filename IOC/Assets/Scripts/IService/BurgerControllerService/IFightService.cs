using System.Collections;
using System.Collections.Generic;
using Components;
using Service;
using UnityEngine;

namespace Service
{
public interface IFightService : IService
{
    void StartFight();

    Entity GetHub();

    Entity GetClosestRessource();


}
}
