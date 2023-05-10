using Addressables;
using Attributes;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        public LevelAssigner level;

        [DependsOnService] private IUIService uiService;
        private int woodAmount;
        private int stoneAmount;
        
        [ServiceInit]
        private void Initialize()
        {
            AddressableHelper.LoadAssetAsyncWithCompletionHandler<GameObject>("Level", GenerateLevel);
        }

        private void GenerateLevel(GameObject gameObject)
        {
            var levelObj = Object.Instantiate(gameObject);
            level = levelObj.GetComponent<LevelAssigner>();
            Release(gameObject);
        }

        public Transform GetWorkerSpawnPosition()
        {
            return level.workerSpawnPosition;
        }

        public Transform GetFreeWorkPlace()
        {
            return level.GetResourcePoint();
        }

        public void AddWood(int amount)
        {
            woodAmount += amount;
            
            uiService.UpdateResourcesUI("Wood", woodAmount);
        }

        public void AddStone(int amount)
        {
            stoneAmount += amount;
            
            uiService.UpdateResourcesUI("Stone", stoneAmount);        }
    }
}