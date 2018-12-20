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

    protected override void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if (hit.tag == "Canceler") return;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            hitScript.TakeDamage(damage);
        }
        //Debug.Log("Ice died to " + hit);
        
        Destroy(gameObject);
    }
}
