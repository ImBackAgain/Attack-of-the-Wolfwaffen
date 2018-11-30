using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {
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
        spellName = "Fuego";
        damage = 2;
        maxRange = 10f;
        aoe = 5f;
        cooldown = 5f;
        cooldownTime = 0f;
        obj = GameObject.Find("Fire");
        casted = false;
        cooldownTime = 0f;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
    }
}
