using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Ventas Fulmino";
        damage = 2;
        maxRange = 5f;
        aoe = 90f;
        cooldown = 5f;
        obj = GameObject.Find("Lightning");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
