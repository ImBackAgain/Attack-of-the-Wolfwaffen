﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCollision : SpellHitbox {
    //int coll;
    float lifetime;
    float maxLifetime;
    Material mat;
    SpelllNegater blocker;


    SphereCollider col;

    // Use this for initialization
    public override void Initialize(float d, string t) {
        base.Initialize(d, t);
        col = GetComponent<SphereCollider>();
        //coll = 0;
        lifetime = 0f;
        maxLifetime = 0.7f;
        mat = GetComponentInChildren<Renderer>().material;
        blocker = gameObject.AddComponent<SpelllNegater>();
        blocker.targetTag = targetTag;
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
        if (other.tag == targetTag)
        {
            GameObject hit = other.gameObject;

            if (hit.GetComponent<BobButEvil>()) return;
            //Don't push bob
            Vector3 away = transform.forward;
            away.Normalize();
            away.y = 0.2f;

            hit.transform.position += away;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);

        GameObject thing = other.gameObject;

        if (thing.tag == "Cancelable" || thing.tag == "Carefullly Cancelable")
        {
            blocker.Nullify(thing.GetComponent<SpellHitbox>());
        }
    }
}
