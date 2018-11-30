using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            Debug.Log("Cast " + spellName);
            casted = true;
            cooldownTime = 0f;
        }
    }

    // Use this for initialization
    void Start () {
        spellName = "Ventas Fulmino";
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
        base.Update();
    }
}
