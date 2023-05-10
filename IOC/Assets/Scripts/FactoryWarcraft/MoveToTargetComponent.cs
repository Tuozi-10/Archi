using UnityEngine;

public class MoveToTargetComponent : IComponent
{
    private Vector3 m_target = Vector3.zero;
    private bool isSetTarget = false;
    private Transform m_transform;
    private Entity entity;

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
        m_transform.position = UnityEngine.Vector3.MoveTowards(m_transform.position, m_target, 0.1f);
        m_target = m_transform.position;
        entity.currentPos = m_transform.position;
    }
}
