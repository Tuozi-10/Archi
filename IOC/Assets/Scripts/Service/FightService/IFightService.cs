using UnityEngine;

public interface IFightService : ISwitchableService
{
    public GameObject currentFighter { get; }

    public void SetFighter(GameObject fighterObj);
}
