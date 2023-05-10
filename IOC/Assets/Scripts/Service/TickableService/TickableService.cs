using Attributes;
using Service;
using Service.FightService;
using Service.TickableService;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

public class TickableService : SwitchableService, ITickableService
{
    [DependsOnService] private IFightService m_fightService;
    public float time;
    public float deltaTime;

    private float duration = 3;
    private float timer;
    
    [ServiceInit]
    private void Initialize()
    {
        Disable();
    }

    private async void Update()
    {
        while (true)
        {
            if (!isActive) return;
            deltaTime = Time.time - time;
            await Task.Yield();
            time += deltaTime;
            OnUpdate();
        }
    }

    protected virtual void OnUpdate()
    {
        //m_fightService.RotateFighter();

        return;
        if (timer >= duration)
        {
            m_fightService.CreateFighter();
            timer = 0f;
        }
        else timer += deltaTime;
    }
    
    public override void Enable()
    {
        base.Enable();
        Update();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
