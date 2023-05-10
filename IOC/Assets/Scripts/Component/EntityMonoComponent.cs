using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Components
{
   [Serializable]
   public class EntityMonoComponent
   {
      public EntityMonoComponentEnum Type;
      public Object Value;
   }
   
}
