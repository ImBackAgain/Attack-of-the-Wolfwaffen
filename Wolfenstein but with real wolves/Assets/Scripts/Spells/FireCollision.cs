﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : SpellHitbox
{
    float dotDamage;
    public GameObject fireAOE;
    GameObject createdObj;
	
    public void Initialize(int d, float ad, string t)
    {
        Initialize(d, t);
        dotDamage = ad;
        fireAOE = Resources.Load<GameObject>("FireAOECollision");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        createdObj = Instantiate(fireAOE, transform.position, Quaternion.identity);
        createdObj.GetComponent<FireAOECollision>().SetDamage(dotDamage);
        Destroy(gameObject);
    }

    protected override void OnHit(GameObject hit)
    {
    }
}
