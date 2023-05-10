using Addressables;
using Attributes;
using DefaultNamespace;
using DesignPattern;
using Service;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.AddressableAssets.Addressables;

public class EntitiesFactoryService : IEntitiesFactoryService
{
    [DependsOnService] private IFightService _fightService;
    
    private EntitySO _lumberjack;
    private EntitySO _harvester;

    private Pool<GameObject> _poolLumberjack;
    private Pool<GameObject> _poolHarvester;

    public void Initialize()
    {
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("Lumberjack", GenerateLumberjack);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<EntitySO>("Harvester", GenerateHarvester);
    }

    public void CreateHarvester()
    {
        var harvester = _poolHarvester.GetFromPool();
        harvester.AddComponent<NavMeshAgent>();
        var agent = harvester.GetComponent<NavMeshAgent>();
        var entity =  harvester.GetComponent<Entity>();
        entity.AddComponent(new MoveToTargetComponent(harvester.transform, agent, _fightService));
        entity.AddComponent(new LumberjackBehaviour(entity));
    }

    public void CreateLumberjack()
    {
        var lumberjack = _poolLumberjack.GetFromPool();
        lumberjack.AddComponent<NavMeshAgent>();
        var agent = lumberjack.GetComponent<NavMeshAgent>();
        var entity = lumberjack.GetComponent<Entity>();
        entity.AddComponent(new MoveToTargetComponent(lumberjack.transform, agent, _fightService));
        entity.AddComponent(new LumberjackBehaviour(entity));
    }

    private void GenerateHarvester(EntitySO harvester)
    {
        _harvester = harvester;
        _poolHarvester = new Pool<GameObject>(_harvester.PrefabEntity);
        Release(harvester);
    }

    private void GenerateLumberjack(EntitySO lumberjack)
    {
        _lumberjack = lumberjack;
        _poolLumberjack = new Pool<GameObject>(_lumberjack.PrefabEntity);
        Release(lumberjack);
    }
}
