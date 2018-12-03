using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Lifeform {
    Gun revolver;
    protected override void Initialize()
    {
        maxHealth = 100;
        revolver = GetComponent<Gun>();
    }

	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire gun") > 0)
        {
            GameObject hit;
            bool hitLifeForm;
            if (revolver.Shoot(out hit, out hitLifeForm, false) && hitLifeForm)
            {
                Destroy(hit);
            }
            
        }
	}
}
