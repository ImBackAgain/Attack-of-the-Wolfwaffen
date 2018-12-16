using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollision : SpellHitbox
{
    bool coll;
    float lifetime;
    float maxLifetime;
	// Use this for initialization
	void Start () {
        damage = 2;
        coll = false;
        lifetime = 0f;
        maxLifetime = 3.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!coll)
        {
            coll = true;
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
