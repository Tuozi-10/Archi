using Addressables;
using Attributes;
using Service.SceneService;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

public class FightService : SwitchableService,IFightService
{
    [DependsOnService] 
    private ISceneService m_sceneService;

    private GameObject enemyPrefab;
    private double previousTickTime;
    private double currentTickTime;
    
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
        m_sceneService.LoadScene(0);
        AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Enemy", SetEnemyPrefab);
    }

    private void SetEnemyPrefab(GameObject prefab)
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
        if (currentTickTime - previousTickTime >= 3)
        {
            previousTickTime = currentTickTime;
            Object.Instantiate(enemyPrefab,Random.onUnitSphere*5,Quaternion.identity);
        }
    }
}
