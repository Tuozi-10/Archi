using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct CompareDistanceComponentData
    {
        public float Distance;
        public CompareDistanceEnum TypeComparaison;
    }
}