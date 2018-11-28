using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {

    private bool projectile;
    private float speed;

    protected override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    void Start () {
        name = "Fuego";
        damage = 2;
        maxRange = 10f;
        aoe = 5f;
        cooldown = 5f;
        cooldownTime = 0f;
        casted = false;
        obj = GameObject.Find("Fire");
        casted = false;
        cooldownTime = 0f;
        speed = 0;
        projectile = false;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        if (casted)
        {
            cooldownTime += Time.deltaTime;
            if (cooldownTime >= cooldown)
            {
                casted = false;
            }
        }
        if (projectile)
        {
            obj.transform.position += obj.transform.forward * speed;
            //Check collisions
            //Explode on collision and remove projectile
            //projectile = false;
        }
    }

    protected override void DrawSpell()
    {
        obj.transform.position = player.transform.position;
        obj.transform.forward = player.transform.forward;
        speed = 1;
        projectile = true;
    }
}
