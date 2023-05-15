using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetComponent : IComponent
{
    private Vector3 m_target = Vector3.zero;
    private bool isSetTarget = false;
    private Transform m_transform;
    private Entity entity;
    private NavMeshAgent m_agent;

    public MoveToTargetComponent(Transform root = null, Entity _entity = null)
    {
        if (root is not null)
        {
            m_transform = root;
            isSetTarget = true;
        }
        
        if (root is not null)
        {
            entity = _entity;
            m_target = entity.GetWoodTarget();
        }

        
    }
        
    public void SetTarget(Vector3 target)
    {
        m_target = target;
    }
        
    public void Init(Vector3 target, Transform myTransform)
    {
        m_target = target;
        m_transform = myTransform;
        isSetTarget = true;
    }

    public void Update()
    {
        if (isSetTarget)
        {
            MoveToTarget();
        }
    }

    public void Init()
    {
        
    }

    private void MoveToTarget()
    {
        m_agent = m_transform.GetComponent<NavMeshAgent>();
        m_agent.SetDestination(m_target);
        m_target = m_transform.position;
        entity.currentPos = m_transform.position;
    }
}
