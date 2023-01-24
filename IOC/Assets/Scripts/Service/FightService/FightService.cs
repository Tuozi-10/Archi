using System.Collections.Generic;
using Addressables;
using Attributes;
using Service.SceneService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class FightService : SwitchableService,IFightService
{
    [DependsOnService] 
    private ISceneService m_sceneService;

    private GameObject enemyPrefab;
    
    private double currentTickTime = 0;
    private double timeSinceLastTime = 0;
    
    
    private string[] enemyNames = new string[] { "Joe", "Jack", "William", "Averell" };
    private List<ScriptableEnemy> scriptableEnemies = new List<ScriptableEnemy>();

    public GameObject currentFighter { get; private set; }

    public void SetFighter(GameObject fighterObj)
    {
        currentFighter = fighterObj;
    }

    public override void Enable()
    {
        base.Enable();
        currentFighter.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();
        currentFighter.SetActive(false);
    }

    [ServiceInit]
    private void StartFighting()
    {
        timeSinceLastTime = Time.time;
        currentTickTime = timeSinceLastTime;
        m_sceneService.LoadScene(0);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Enemy", LoadEnemyPrefab);
        scriptableEnemies.Clear();
        foreach (var t in enemyNames)
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<ScriptableEnemy>(t, AddScriptableEnemy);
        }
    }
    
    void AddScriptableEnemy(ScriptableEnemy so)
    {
        scriptableEnemies.Add(so);
    }

    private void LoadEnemyPrefab(GameObject prefab)
    {
        enemyPrefab = prefab;
        Release(prefab);
    }

    [OnTick]
    private void SpinBurger()
    {
        if(enable && currentFighter != null) currentFighter.transform.localRotation *= Quaternion.Euler(new Vector3(0,10,0));
    }
    
    
    [OnTick]
    private void TrySpawn()
    {
        currentTickTime = Time.time;
        if (currentTickTime - timeSinceLastTime >= 3)
        {
            timeSinceLastTime = currentTickTime;
            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        var enemyComponent = Object.Instantiate(enemyPrefab,Random.onUnitSphere*5,Quaternion.identity).GetComponent<EnemyComponent>();
        enemyComponent.enemy = scriptableEnemies[Random.Range(0, scriptableEnemies.Count)].CreateEnemy();
        Logs.Log($"Spawned {enemyComponent.enemy}");
    }
}
