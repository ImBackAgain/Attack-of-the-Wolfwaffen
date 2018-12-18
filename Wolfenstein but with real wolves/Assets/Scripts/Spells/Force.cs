using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            //Debug.Log("Force");
            casted = true;
            cooldownTime = 0f;

            DrawSpell();
            
            //push back
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Assantius", 1, 5);
    }

    // Update is called once per frame
    public override void Update ()
    {
        if (casted)
        {
            cooldownTime += Time.deltaTime;
            if (cooldownTime >= cooldown)
            {
                casted = false;
            }
        }
    }

    protected override void DrawSpell()
    {
        //Debug.Log("Asssantius");
        CreateProjectile();
        createdObj.GetComponent<ForceCollision>().Initialize(damage, targetTag);
    }
}
