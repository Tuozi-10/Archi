using System.Collections;
using System.Collections.Generic;
using Service;
using UnityEngine;

namespace Service
{
public interface IFightService : IService
{
   GameObject fighter { set; }
}
}
