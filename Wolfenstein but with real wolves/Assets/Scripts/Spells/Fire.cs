using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {
    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Fuego";
        damage = 2;
        maxRange = 10f;
        aoe = 5f;
        cooldown = 5f;
        obj = GameObject.Find("Fire");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
