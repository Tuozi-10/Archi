using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;
[CreateAssetMenu(fileName = "new AgentSO", menuName = "Entity/AgentSO" , order = 0)]
public class AgentSO : ScriptableObject
{
   public RessourceComponentData RessourceComponentData;
   public SteelRessourceComponentData SteelRessourceComponentData;
   public MoveToTargetComponentData MoveToTargetComponentData;
   public TimerComponentData HarvestTimeComponentData;
   public TimerComponentData DropTimeComponentData;
}
