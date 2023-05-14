using System;
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
   public CompareDistanceComponentData DistanceComponentData;
   public StateMachineComponentData StateMachineComponentData;
   public AgentStateEnum StartState;

   private void OnValidate()
   {
      StateMachineComponentData.StartState = (int)StartState;
   }
}
