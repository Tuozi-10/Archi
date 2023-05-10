using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct RessourceComponentData
    {
        [field: SerializeField] public int StartRessourceCount { get; set; }
    }
}