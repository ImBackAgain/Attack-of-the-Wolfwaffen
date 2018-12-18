using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Ventus Fulmino", 4, 5);
    }

   
    protected override void DrawSpell()
    {
        CreateProjectile();
        createdObj.GetComponent<LightningCollision>().Initialize(damage, targetTag);
    }
}
