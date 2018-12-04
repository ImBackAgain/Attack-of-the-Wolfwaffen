using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    private Spells[] spells;

	// Use this for initialization
	void Start ()
    {
        spells = new Spells[6];
        spells[0] = GetComponent<Fire>();
        spells[1] = GetComponent<Ice>();
        spells[2] = GetComponent<Lightning>();
        spells[3] = GetComponent<Force>();
        spells[4] = GetComponent<Wind>();
        spells[5] = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton("CastFire")) spells[0].Cast();
        if (Input.GetButton("CastIce")) spells[1].Cast();
        if (Input.GetButton("CastLightning")) spells[2].Cast();
        if (Input.GetButton("CastForce")) spells[3].Cast();
        if (Input.GetButton("CastWind")) spells[4].Cast();
        if (Input.GetButton("CastGravity")) spells[5].Cast();
    }
}
