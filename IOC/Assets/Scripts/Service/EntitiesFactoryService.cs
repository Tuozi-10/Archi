using DefaultNamespace;
using entities;
using Service;
using UnityEngine;

namespace Dp.DesignPatterns
{
    public class EntitiesFactoryService : IEntitiesFactoryService
    {
        private entitySO m_lumberjack;
        private entitySO m_harvester;

        private Transform tree;
        private Transform stone;
        
        public Entity CreateHarvester()
        {
            Entity harvester = new Entity(m_harvester);
            harvester.AddComponent(new MoveToTargetComponent(tree));
            // todo create harvester behaviour
            
            return harvester;
        }

        public Entity CreateLumberjack()
        {
            Entity lumberjack = new Entity(m_lumberjack);
            lumberjack.AddComponent(new MoveToTargetComponent(stone));
            lumberjack.AddComponent(new LumberjackBehaviour(lumberjack));
            return lumberjack;
        }
    }
}