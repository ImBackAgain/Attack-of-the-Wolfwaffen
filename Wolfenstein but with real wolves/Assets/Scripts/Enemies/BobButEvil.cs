using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobButEvil : Enemy {
    

    protected override void Initialize()
    {
        healthOfffset = 0.7f;
        healthScalar = 0.128f / transform.localScale.x;
        Initialize(300);
    }

    protected override void BeIntelligent()
    {
        //throw new System.NotImplementedException();
    }
    
}
