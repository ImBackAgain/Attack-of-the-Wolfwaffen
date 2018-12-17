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

    protected override void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        if (hit.tag == "Cancelable" || hit.tag == "Carefullly Cancelable")
        {
            if (hit.tag == "Carefullly Cancelable")
            {
                Debug.Log("Destroying lightning;");
            }
            Destroy(other.gameObject);
        }
        else if (hit.tag == targetTag)
        {
            Vector3 away = transform.forward;
            away.Normalize();
            away.y = 1;

            hit.transform.position += away;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);
    }
}
