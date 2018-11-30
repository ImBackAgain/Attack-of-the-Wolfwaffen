using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Lifeform {
    Gun revolver;

    Dictionary<string, Spells> spells = new Dictionary<string, Spells>();

    protected override void Initialize()
    {
        Initialize(100);
        revolver = GetComponent<Gun>();

        spells.Add("Fire", GameObject.Find("Fire").GetComponent<Fire>());
        spells.Add("Force", GameObject.Find("Force").GetComponent<Force>());
        spells.Add("Gravity", GameObject.Find("Gravity").GetComponent<Gravity>());
        spells.Add("Ice", GameObject.Find("Ice").GetComponent<Ice>());
        spells.Add("Lightning", GameObject.Find("Lightning").GetComponent<Lightning>());
        spells.Add("Wind", GameObject.Find("Wind").GetComponent<Wind>());
    }

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire gun"))
        {
            GameObject hit;
            bool hitLifeForm;
            if (revolver.Shoot(out hit, out hitLifeForm, false) && hitLifeForm)
            {
                Destroy(hit);
            }   
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
