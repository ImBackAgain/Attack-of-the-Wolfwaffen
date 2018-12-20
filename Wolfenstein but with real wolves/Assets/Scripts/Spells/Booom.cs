using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booom : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    protected override void DrawSpell()
    {
        CreateProjectile();
        createdObj.GetComponent<BooomColllision>().Initialize(damage, targetTag);
    }

    protected override void Initialize()
    {
        Initialize("Bobbbus Explodus", 0.1f, 8);
    }
}
