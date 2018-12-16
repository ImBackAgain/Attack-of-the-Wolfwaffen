using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {

    private bool projectile;
    private float speed;

    public override void Cast()
    {
        if (!casted)
        {
            Debug.Log("Cast " + spellName);
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Fuego", 2, 10, 5);
        speed = 0.25f;
        projectile = false;
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
        if(createdObj == null)
        {
            projectile = false;
        }
        if (projectile)
        {
            createdObj.transform.position += createdObj.transform.forward * speed;
        }
    }

    protected override void DrawSpell()
    {
        CreateProjectile();
        createdObj.GetComponent<FireCollision>().Initialize(damage, (float)damage / 2, targetTag);
        projectile = true;
    }
}
