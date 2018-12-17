using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollision : SpellHitbox
{
    bool collided = false;
    float lifetime;
    float maxLifetime;
	// Use this for initialization
	public override void Initialize(float d, string t) {
        base.Initialize(d, t);
        lifetime = 0f;
        maxLifetime = 3.0f;
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

   

    protected override void OnHit(GameObject hit)
    {
    }
}
