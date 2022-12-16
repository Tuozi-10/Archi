using UnityEngine;

public class FightService : SwitchableService,IFightService
{
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
}
