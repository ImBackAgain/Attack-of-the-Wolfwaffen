using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Spells {
    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Ventus Servitas";
        damage = 1;
        maxRange = 3f;
        aoe = 3f;
        cooldown = 5f;
        obj = GameObject.Find("Wind");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
