using Component;
using Service;
using UnityEngine;

namespace Entities
{
    public class HarvesterBehaviour : StateMachineComponent
    {
        private IGameService gameService;
        
        private MoveToTargetComponent moveToTargetComponent;
        private InventoryComponent inventoryComponent;
        
        public HarvesterBehaviour(Entity owner, IGameService gameService) : base(owner)
        {
            this.gameService = gameService;
        }

        public override void Init()
        {
            base.Init();
            moveToTargetComponent = m_entity.GetComponent<MoveToTargetComponent>();
            inventoryComponent = m_entity.GetComponent<InventoryComponent>();

            ChangeState(States.Wander);
        }

        protected override void ChangeToWander()
        {
            base.ChangeToWander();
            GetNewPosition();
        }

        private void GetNewPosition()
        {
            if (moveToTargetComponent != null)
            {
                moveToTargetComponent.SetTarget(gameService.GetFreeWorkPlace());
            }
        }

        protected override void DoWander()
        {
            base.DoWander();
            float distance = Vector3.Distance(moveToTargetComponent.GetTarget().position, m_entity.transform.position);
            
            if (distance < 0.5f)
            {
                ChangeState(States.Harvest);
            }
        }

        protected override void DoHarvest()
        {
            base.DoHarvest();
            
            if (m_entity)
            {
                Compositor.OnTickAction += AddHarvestToInventory;
            }
        }

        protected override void ChangeToCraft()
        {
            base.ChangeToCraft();
            
            moveToTargetComponent.SetTarget(gameService.GetWorkerSpawnPosition());
        }

        protected override void DoCraft()
        {
            base.DoCraft();
            
            float distance = Vector3.Distance(moveToTargetComponent.GetTarget().position, m_entity.transform.position);
            
            if (distance < 0.5f)
            {
                ChangeState(States.Wander);
            }
        }

        private void AddHarvestToInventory()
        {
            if (!inventoryComponent.AddResources(m_entity.data.targetResources, 5))
            {
                ChangeState(States.Craft);
                Compositor.OnTickAction -= AddHarvestToInventory;
            }
        }
    }
}