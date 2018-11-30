using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            Debug.Log("Cast " + spellName);
            casted = true;
            cooldownTime = 0f;
            //Raycast collision detection
            //Deal effect on hit
        }
    }

    // Use this for initialization
    void Start () {
        spellName = "Assantius";
        damage = 1;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        obj = GameObject.Find("Force");
        casted = false;
        cooldownTime = 0f;
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
    }

    protected override void DrawSpell()
    {
        throw new System.NotImplementedException();
    }
}
