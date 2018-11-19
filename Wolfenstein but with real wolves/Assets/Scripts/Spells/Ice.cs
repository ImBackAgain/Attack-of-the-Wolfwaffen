using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Spells {
    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Infriga";
        damage = 3;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        //obj = 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
