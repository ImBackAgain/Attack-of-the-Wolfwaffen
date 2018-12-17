using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollision : SpellHitbox
{
    readonly float speeed = 0.5f;
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speeed;
    }

    protected override void OnHit(GameObject hit)
    {
        Destroy(gameObject);
    }
}
