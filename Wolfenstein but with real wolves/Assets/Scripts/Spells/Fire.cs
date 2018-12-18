using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {

    private bool projectile;
    
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
        Initialize("Fuego", 2, 6);
        
        projectile = false;
    }

    
    protected override void DrawSpell()
    {
        CreateProjectile();
        createdObj.GetComponent<FireCollision>().Initialize(damage, (float)damage /120, targetTag);
        projectile = true;
    }
}
