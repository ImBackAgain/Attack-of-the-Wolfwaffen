using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP40 : Gun {
    protected override void Initialize()
    {
        base.Initialize(12, 12, 0.2f, 1, 4);
    }
}
