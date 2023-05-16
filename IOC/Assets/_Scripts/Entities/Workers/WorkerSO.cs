using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Workers
{
    [CreateAssetMenu(menuName = "WorkerSO", fileName = "new WorkerSO")]
    public class WorkerSO : ScriptableObject
    {
        public int Health;
        public int Speed;
        public int Quantity;
        public int HarvestTime;
        [FormerlySerializedAs("PrefabEntity")] public GameObject PrefabWorker;

        Worker GetWorker()
        {
            return new Worker(this);
        }
    }
}