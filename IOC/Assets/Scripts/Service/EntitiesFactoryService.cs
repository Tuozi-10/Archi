using System.Threading.Tasks;
using Addressables;
using DefaultNamespace;
using entities;
using Service;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Dp.DesignPatterns
{
    public class EntitiesFactoryService : SwitchableService, IEntitiesFactoryService
    {
        private entitySO m_lumberjack;
        private entitySO m_harvester;

        public void CreateHarvester()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Harvester", CreateHarvesterAsync);
        }

        private void CreateHarvesterAsync(GameObject harvester)
        {
            var go = Object.Instantiate(harvester);
            go.AddComponent<Entity>().SetData(m_harvester);
            var entity = go.GetComponent<Entity>();
            entity.AddComponent(new ResourceFinderComponent(entity, ResourceType.Stone));
            entity.AddComponent(new MoveToTargetComponent(entity));
            entity.AddComponent(new HarvesterBehaviour(entity));
            Release(harvester);
        }

        public void CreateLumberjack()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Lumberjack", CreateLumberjackAsync);
        }

        private void CreateLumberjackAsync(GameObject lumberjack)
        {
            var go = Object.Instantiate(lumberjack);
            go.AddComponent<Entity>().SetData(m_lumberjack);
            var entity = go.GetComponent<Entity>();
            entity.AddComponent(new ResourceFinderComponent(entity, ResourceType.Tree));
            entity.AddComponent(new MoveToTargetComponent(entity));
            entity.AddComponent(new LumberjackBehaviour(entity));
            Release(lumberjack);
        }

        public async void Text()
        {
            await Task.Yield();
        }

        public override void Enable()
        {
            if (isActive) return;
            base.Enable();
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableObject>("LumberjackSO", GenerateLumberjack);
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableObject>("HarvesterSO", GenerateHarvester);

            // Create one of both categories
            CreateHarvester();
            CreateLumberjack();
        }

        private void GenerateLumberjack(ScriptableObject so)
        {
            m_lumberjack = so as entitySO;
            Release(so);
        }

        private void GenerateHarvester(ScriptableObject so)
        {
            m_harvester = so as entitySO;
            Release(so);
        }

        public bool isActive { get; }
    }
}