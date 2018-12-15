using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luger : Gun {
    protected override void Initialize()
    {
        Initialize(2, 12, 0.2f, 2, 3);
    }
}
