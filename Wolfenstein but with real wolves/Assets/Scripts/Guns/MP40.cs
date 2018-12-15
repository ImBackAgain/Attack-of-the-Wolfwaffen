using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP40 : Gun {
    protected override void Initialize()
    {
        Initialize(1, 100, 0.5f, 3, 5);
    }
}
