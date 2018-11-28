using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    protected override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
        }
    }

    // Use this for initialization
    void Start () {
        name = "Assantius";
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
}
