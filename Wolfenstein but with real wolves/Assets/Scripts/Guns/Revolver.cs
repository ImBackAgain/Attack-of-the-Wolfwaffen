using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun {
    protected override void Initialize()
    {
        Initialize(12, 120, 0.2f, 1, 4);
    }
}
