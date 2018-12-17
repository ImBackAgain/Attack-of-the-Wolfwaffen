using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollision : SpellHitbox
{
    bool collided = false;
    float lifetime;
    float maxLifetime = 1;
	// Use this for initialization
	public override void Initialize(float d, string t) {
        base.Initialize(d, t);
        lifetime = 0f;
	}


    // Update is called once per frame
    void Update ()
    {
        if (!collided)
        {
            collided = true;
            GetComponent<Collider>().enabled = false;
        }
		if(lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
        lifetime += Time.deltaTime;
	}


    protected override void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            hitScript.TakeDamage(damage);
            OnHit(hit);
        }
    }
}
