using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollision : SpellHitbox
{
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnHit(GameObject hit)
    {
        Destroy(gameObject);
    }
}
