using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCollision : SpellHitbox {
    int coll;
    float lifetime;
    float maxLifetime;
    Material mat;
    // Use this for initialization
    public override void Initialize(float d, string t) {
        base.Initialize(d, t);  
        coll = 0;
        lifetime = 0f;
        maxLifetime = 0.7f;
        mat = GetComponentInChildren<Renderer>().material;
	}

    void FixedUpdate()
    {
        if (coll < 3)
        {
            coll++;
        }
        if (coll == 2)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 0.01f;

        Color col = mat.color;

        col.a = 1 - lifetime / maxLifetime;

        mat.color = col;

        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
        lifetime += Time.deltaTime;
    }



    protected override void OnHit(GameObject hit)
    {
    }
}
