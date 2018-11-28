﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Spells {

    protected float duration;
    private float timer;
    private bool activated;

    protected override void Cast()
    {
        if (!casted)
        {
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
        }
    }

    // Use this for initialization
    void Start () {
        name = "Ventus Servitas";
        damage = 1;
        maxRange = 3f;
        aoe = 3f;
        cooldown = 10f;
        obj = GameObject.Find("Wind");
        duration = 5f;
        casted = false;
        timer = 0f;
        activated = false;
        cooldownTime = 0f;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        if (activated)
        {
            timer += Time.deltaTime;
            //draw aoe wind effect and check for collision
            if (timer >= duration)
            {
                activated = false;
            }
        }

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
