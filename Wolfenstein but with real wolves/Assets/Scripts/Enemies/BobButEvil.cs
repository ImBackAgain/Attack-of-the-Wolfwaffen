using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobButEvil : Enemy {
    

    protected override void Initialize()
    {
        Initialize(300);
    }

    protected override void BeIntelligent()
    {
        throw new System.NotImplementedException();
    }
}
