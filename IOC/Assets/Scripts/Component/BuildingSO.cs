using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;

namespace Components
{
   [CreateAssetMenu(fileName = "new BuildingSO", menuName = "Entity/BuildingSO" , order = 0)]
public class BuildingSO : EntitySO
{
   public RessourceComponentData RessourceComponentData;
}
}
