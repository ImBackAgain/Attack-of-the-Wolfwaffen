using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    protected override void Cast()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        name = "Assantius";
        damage = 1;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        obj = GameObject.Find("Force");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
