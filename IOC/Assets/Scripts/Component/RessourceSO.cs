using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
[CreateAssetMenu(fileName = "new RessourceSO", menuName = "Entity/RessourceSO" , order = 0)]
public class RessourceSO : ScriptableObject
{
   public RessourceComponentData RessourceComponentData;
}
}
