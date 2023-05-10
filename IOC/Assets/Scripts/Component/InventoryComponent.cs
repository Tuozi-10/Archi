using System.Collections.Generic;
using Attributes;
using DefaultNamespace;
using Service;
using UnityEngine;

namespace Component
{
    public class InventoryComponent : IComponent
    {
        private IUIService uiService;
        
        public Dictionary<ResourcesSO, int> inventory;

        public bool AddResources(ResourcesSO rs, int count)
        {
            if (inventory.ContainsKey(rs))
            {
                if (inventory[rs] < rs.maxStack)
                {
                    inventory[rs] += count;
                    return true;
                }
            }
            else
            {
                inventory.Add(rs, count);
                return true;
            }

            if (inventory[rs] + count > rs.maxStack)
            {
                inventory[rs] = rs.maxStack;
            }
            
            return false;
        }
        
        public void Init()
        {
            inventory = new Dictionary<ResourcesSO, int>();
        }

        public void Update()
        {
        }
    }
}