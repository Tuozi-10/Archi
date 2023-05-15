using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    private Composite MyComposite;
    
    public void SetComposite(Composite _composite)
    {
        MyComposite = _composite;
    }
    
    public void Update()
    {
        MyComposite.Update();
    }
}
