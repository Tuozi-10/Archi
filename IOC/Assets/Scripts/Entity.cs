using DefaultNamespace;
using Dp.DesignPatterns;
using UnityEngine;

namespace entities
{
    public class Entity : Composite
    {
        // data for our entity, hp, gold, stone, wood, speed ... 
        private entitySO data;
        public int wood, stone;
        private int maxWood, maxStone;
        public bool isFull;
        
        public void SetData(entitySO data)
        {
            this.data = data;
            transform.position = Vector3.zero;
            maxWood = data.maxWood;
            maxStone = data.maxStone;
        }

        public void GetWood()
        {
            if (wood == maxWood)
            {
                isFull = true;
                return;
            }
            wood++;
        }

        public void GetStone()
        {
            if (stone == maxStone)
            {
                isFull = true;
                return;
            }
            stone++;
        }
    }
}