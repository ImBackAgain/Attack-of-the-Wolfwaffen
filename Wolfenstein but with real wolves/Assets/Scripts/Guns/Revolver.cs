using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun {
    protected override void Initialize()
    {
        Initialize(3, 120, 0.5f, 1, 6);
    }
}
