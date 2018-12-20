using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollision : SpellHitbox
{
    bool collided = false;
    readonly float maxLifetime = 1;
    HashSet<Lifeform> colllisions;
    
	// Use this for initialization
	public override void Initialize(float d, string t) {
        base.Initialize(d, t);
        Destroy(gameObject, maxLifetime);
        colllisions = new HashSet<Lifeform>();
	}


    // Update is called once per frame
    void Update ()
    {
        if (!collided)
        {
            collided = true;
            GetComponent<Collider>().enabled = false;
            foreach(Lifeform hit in colllisions)
            {
                hit.TakeDamage(damage);
            }
        }
	}


    protected override void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            colllisions.Add(hitScript);
        }
    }
}
