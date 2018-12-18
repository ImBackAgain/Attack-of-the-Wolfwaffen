﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BooomColllision : SpellHitbox
{
    float lifetime;
    float maxLifetime;


    // Use this for initialization
    public override void Initialize(float d, string t)
    {
        base.Initialize(d, t);
        
        lifetime = 0f;
        maxLifetime = 1.0f;

        transform.forward = Vector3.forward;
    }

    void Update()
    {
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
        lifetime += Time.deltaTime;
    }


    protected override void OnHit(GameObject hit)
    {
        if (hit.tag == "Player")
        {
            //Debug.Log("Touching player");
            Vector3 away = hit.transform.position - transform.position;
            away = away.normalized * 60;
            away.y = 3;


            FirstPersonController dresdenScript = hit.GetComponent<FirstPersonController>();

            CharacterController dresdenCont = hit.GetComponent<CharacterController>();

            dresdenCont.SimpleMove(away);

            dresdenScript.m_Jump = true;
        }
    }
    protected override void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            OnHit(hit);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            hitScript.TakeDamage(damage);
        }
    }
}
