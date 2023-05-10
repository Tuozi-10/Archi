using System.Diagnostics;
using UnityEngine;

public class LevelAssigner : MonoBehaviour
{
    public Transform workerSpawnPosition;
    public ResourcesPoint[] resourcesPoints;

    public Transform GetResourcePoint()
    {
        return resourcesPoints[Random.Range(0, resourcesPoints.Length)].transform;
    }
}
