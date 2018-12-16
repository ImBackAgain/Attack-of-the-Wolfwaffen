using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Lifeform {
    Gun revolver;
    Transform child;

    public override Vector3 Forward
    {
        get
        {
            return child.forward;
        }
    }

    public float HealthRatio
    {
        get { return (float)health / maxHealth; }
    }

    public int AmmoLeft
    {
        get { return revolver.Ammo; }
    }
    Dictionary<string, Spells> spells = new Dictionary<string, Spells>();

    protected override void Initialize()
    {
        Initialize(30);
        revolver = GetComponent<Gun>();

        spells.Add("Fire", GetComponent<Fire>());
        spells.Add("Force", GetComponent<Force>());
        spells.Add("Gravity", GetComponent<Gravity>());
        spells.Add("Ice", GetComponent<Ice>());
        spells.Add("Lightning", GetComponent<Lightning>());
        spells.Add("Wind", GetComponent<Wind>());

        child = GetComponentInChildren<Transform>();
    }

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire gun"))
        {
            revolver.Shoot(transform.position, Forward, true);
        }

        if (Input.GetButtonDown("Reload gun"))
        {
            revolver.Reload();
        }

        foreach(string spelllName in spells.Keys)
        {
            if (Input.GetButtonDown("Cast" + spelllName))
            {
                spells[spelllName].Cast();
            }
        }
	}
}
