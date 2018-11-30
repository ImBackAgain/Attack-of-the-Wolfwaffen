using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Spells {

    protected float duration;
    private float timer;
    private bool activated;

    protected override void Cast()
    {
        if(!casted)
        {
            Debug.Log("Cast " + spellName);
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
            //modify jump
        }
    }

    // Use this for initialization
    void Start () {
        spellName = "Gravitus";
        damage = 0;
        maxRange = 0f;
        aoe = 0f;
        cooldown = 10f;
        duration = 5f;
        obj = GameObject.Find("Gravity");
        casted = false;
        timer = 0f;
        activated = false;
        cooldownTime = 0f;
    }

    // Update is called once per frame
    protected override void Update ()
    {
		if(activated)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                activated = false;
                //modify jump
            }
        }

        if(casted)
        {
            cooldownTime += Time.deltaTime;
            if(cooldownTime >= cooldown)
            {
                casted = false;

            }
        }
	}
}
