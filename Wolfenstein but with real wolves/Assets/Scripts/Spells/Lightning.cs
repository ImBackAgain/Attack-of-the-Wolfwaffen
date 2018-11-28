using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
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
        name = "Ventas Fulmino";
        damage = 2;
        maxRange = 5f;
        aoe = 90f;
        cooldown = 5f;
        obj = GameObject.Find("Lightning");
        casted = false;
        cooldownTime = 0f;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        if (casted)
        {
            cooldownTime += Time.deltaTime;
            obj.transform.position = player.transform.position;
            //Check collision
            //Deal damage if within collision
            if (cooldownTime >= cooldown)
            {
                casted = false;
            }
        }
    }

    protected override void DrawSpell()
    {
        obj.transform.position = player.transform.position;
    }
}
