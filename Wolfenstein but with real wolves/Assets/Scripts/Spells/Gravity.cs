using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Spells {

    protected float duration;

    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Gravitus";
        damage = 0;
        maxRange = 0f;
        aoe = 0f;
        cooldown = 10f;
        duration = 5f;
        obj = GameObject.Find("Gravity");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
