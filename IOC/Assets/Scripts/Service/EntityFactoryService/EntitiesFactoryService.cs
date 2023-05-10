using Addressables;
using Attributes;
using Component;
using Entities;
using Service;
using UnityEngine;
using UnityEngine.AI;

public class EntitiesFactoryService : IEntitiesFactoryService
{
    private EntitySO m_harvester;
    private EntitySO m_lumberjack;
    private EntitySO m_blacksmith;
    
    private Pool<GameObject> harvesterPool;
    private Pool<GameObject> lumberjackPool;
    private Pool<GameObject> blacksmithPool;

    [DependsOnService] private IGameService gameService;

    [ServiceInit]
    private void Initialize()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("HarvesterData", so => m_harvester = so);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("LumberjackData", so => m_lumberjack = so);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("BlacksmithData", so => m_blacksmith = so);

        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Harvester", InitHarvester);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Lumberjack", InitLumberjack);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Blacksmith", InitBlacksmith);
    }
    
    private void InitHarvester(GameObject obj)
    {
        harvesterPool = new Pool<GameObject>(obj);
    }
    private void InitLumberjack(GameObject obj)
    {
        lumberjackPool = new Pool<GameObject>(obj);
    }
    private void InitBlacksmith(GameObject obj)
    {
        blacksmithPool = new Pool<GameObject>(obj);
    }

    public void CreateHarvester()
    {
        Entity harvester = harvesterPool.GetFromPool().AddComponent<Entity>();
        harvester.data = m_harvester;
        
        harvester.transform.position = gameService.GetWorkerSpawnPosition().position;
        NavMeshAgent agent = harvester.gameObject.AddComponent<NavMeshAgent>();

        harvester.AddComponent(new HarvesterBehaviour(harvester, gameService));
        harvester.AddComponent(new MoveToTargetComponent(agent));
        harvester.AddComponent(new InventoryComponent());
            
        harvester.Init();
    }

    public void CreateLumberjack()
    {
        Entity lumberjack = lumberjackPool.GetFromPool().AddComponent<Entity>();
        lumberjack.data = m_lumberjack;

        lumberjack.transform.position = gameService.GetWorkerSpawnPosition().position;
        NavMeshAgent agent = lumberjack.gameObject.AddComponent<NavMeshAgent>();

        lumberjack.AddComponent(new HarvesterBehaviour(lumberjack, gameService));
        lumberjack.AddComponent(new MoveToTargetComponent(agent));
        lumberjack.AddComponent(new InventoryComponent());

        lumberjack.Init();
    }

    public void CreateBlacksmith()
    {
        Entity blacksmith = blacksmithPool.GetFromPool().AddComponent<Entity>();
        blacksmith.data = m_blacksmith;
        
        blacksmith.transform.position = gameService.GetWorkerSpawnPosition().position;
        NavMeshAgent agent = blacksmith.gameObject.AddComponent<NavMeshAgent>();
        
        blacksmith.AddComponent(new HarvesterBehaviour(blacksmith, gameService));
        blacksmith.AddComponent(new MoveToTargetComponent(agent));
        blacksmith.AddComponent(new InventoryComponent());

        blacksmith.Init();
        
    }
}
