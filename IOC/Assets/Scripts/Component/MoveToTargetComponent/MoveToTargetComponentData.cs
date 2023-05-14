using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    [Serializable]
    public struct MoveToTargetComponentData
    {
        [FormerlySerializedAs("Speed")] public float Time;
    }
}