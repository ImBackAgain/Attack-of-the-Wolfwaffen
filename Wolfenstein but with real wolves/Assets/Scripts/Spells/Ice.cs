using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Spells {
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
        spellName = "Infriga";
        damage = 3;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        obj = GameObject.Find("Ice");
        casted = false;
        cooldownTime = 0f;
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
    }
}
