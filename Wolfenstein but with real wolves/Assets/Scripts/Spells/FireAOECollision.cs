using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAOECollision : MonoBehaviour {
    float damage;
    readonly float lifespan = 1f;
    float timer = 0;

	// Use this for initialization
	public void SetDamage(float damage)
    {
        this.damage = damage;
    }
	// Update is called once per frame
	void Update () {
		if ((timer += Time.deltaTime) >= lifespan)
        {
            Destroy(gameObject);
        }
        //Color c = mat.color;
        //c.a = 1 - timer / lifespan;
        //mat.color = c;

        
	}

    private void OnTriggerStay(Collider collision)
    {
        //Debug.Log("fire aoe collision");
        Lifeform hit = collision.GetComponent<Lifeform>();
        if (hit)
        {
            hit.TakeDamage(damage);
        }
    }
}
