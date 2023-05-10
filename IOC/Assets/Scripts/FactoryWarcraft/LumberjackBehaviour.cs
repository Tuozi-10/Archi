using UnityEngine;

public class LumberjackBehaviour : StateMachineComponent
{
    float timer = 5f;

    public LumberjackBehaviour(Entity owner) : base(owner)
    {
    }

    public override void Init()
    {
        ChangeState(states.wander);
        //m_entity.OnIdle?.Invoke();
    }

    protected override void DoIdle()
    {
    }

    protected override void DoWander()
    {
        if (m_entity)
        {
            MoveToTargetComponent moveComponent = m_entity.myGetComponent<MoveToTargetComponent>();
            if (Vector3.Distance(m_entity.GetWoodTarget(), m_entity.currentPos) > 1f)
                moveComponent.SetTarget(m_entity.GetWoodTarget());
            else
                ChangeState(states.harvest);
        }
    }

    protected override void DoHarvest()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeState(states.GoToBase);
            timer = 5f;
        }
    }

    protected override void DoGoToBase()
    {
        if (m_entity)
        {
            MoveToTargetComponent moveComponent = m_entity.myGetComponent<MoveToTargetComponent>();
            if (Vector3.Distance(Vector3.zero, m_entity.currentPos) > 1f)
                moveComponent.SetTarget(Vector3.zero);
            else
            {
                m_entity.OnGainRessource?.Invoke(10);
                ChangeState(states.wander);
            }
        }
    }
}

public class BlackSmithBehaviour : StateMachineComponent
{
    float timer = 5f;
    MoveToTargetComponent moveComponent = null;

    public BlackSmithBehaviour(Entity owner) : base(owner)
    {
    }

    public override void Init()
    {
        ChangeState(states.idle);
    }

    private void OnReceiveInfoRessource(bool state)
    {
        if (state)
        {
            m_entity.OnCreateTool?.Invoke();
            ChangeState(states.wander);
        }
    }

    protected override void DoIdle()
    {
        m_entity.OnIdle?.Invoke(m_entity);
        m_entity.OnReceiveInfo = OnReceiveInfoRessource;
    }

    protected override void DoWander()
    {
        if (m_entity)
        {
            if (moveComponent == null)
                moveComponent = m_entity.myGetComponent<MoveToTargetComponent>();
            if (Vector3.Distance(m_entity.GetWoodTarget(), m_entity.currentPos) > 1f)
                moveComponent.SetTarget(m_entity.GetWoodTarget());
            else
                ChangeState(states.harvest);
        }
    }

    protected override void DoHarvest()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeState(states.GoToBase);
            timer = 10f;
        }
    }

    protected override void DoGoToBase()
    {
        if (m_entity)
        {
            if (Vector3.Distance(Vector3.zero, m_entity.currentPos) > 1f)
                moveComponent.SetTarget(Vector3.zero);
            else
            {
                m_entity.OnGainRessource?.Invoke(1);
                ChangeState(states.idle);
            }
        }
    }
}