using Addressables;
using Attributes;
using UnityEngine;
using static UnityEngine.AddressableAssets.Addressables;

namespace Service
{
    public class GameService : IGameService
    {
        public LevelAssigner level;
        
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
    }
}