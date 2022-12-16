using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service
{
public interface ISwitchableService : IService
{
   public void EnabledService();
   public void DisabledService();
   public bool GetIsActiveService();
}
}
