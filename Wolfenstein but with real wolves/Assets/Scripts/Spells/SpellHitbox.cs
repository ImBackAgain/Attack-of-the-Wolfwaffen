using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellHitbox : MonoBehaviour {

    protected float damage;
    public string targetTag;

	// Use this for initialization
	public virtual void Initialize(float d, string t)
    {
        damage = d;
        targetTag = t;
        GetComponent<AudioSource>().Play();
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        GameObject hit = other.gameObject;
        Lifeform hitScript;
        if ((hit.tag == targetTag) && (hitScript = hit.GetComponent<Lifeform>()))
        {
            hitScript.TakeDamage(damage);
            OnHit(hit);
        }
    }

    protected virtual void OnHit(GameObject hit)
    {

    }
}
