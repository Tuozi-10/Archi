


using System.Collections.Generic;
using UnityEngine;

namespace  Components
{
    public class Entity : Composite
    {
        [SerializeField] private List<EntityMonoComponent> _startMonoComponent;
        public readonly Dictionary<EntityMonoComponentEnum, Object> AllMonoComponents= new Dictionary<EntityMonoComponentEnum, Object>();
        public void Init()
        {
            for (int i = 0; i < _startMonoComponent.Count; i++)
            {
                AllMonoComponents.Add(_startMonoComponent[i].Type, _startMonoComponent[i].Value);
            }
        }
     
    }
}