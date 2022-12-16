using System.Collections;
using System.Collections.Generic;
using Service;
using Service.TickService;
using UnityEngine;

public class BurgerModifier : MonoBehaviour
{
    [SerializeField] private Vector2 scaleRange;
    [SerializeField] private float scaleSpeed = .1f;
    private bool scalingUp;
    
    
    public void Setup(IGameService gameService, ITickService tickService)
    {
        tickService.OnUpdate += OnUpdate;
    }

    void OnUpdate()
    {
        transform.Rotate(Vector3.forward);
        transform.localScale += scalingUp ? Vector3.one * scaleSpeed : -Vector3.one * scaleSpeed;
        if (transform.localScale.x < scaleRange.x) scalingUp = true;
        else if (transform.localScale.x > scaleRange.y) scalingUp = false;
    }
}
