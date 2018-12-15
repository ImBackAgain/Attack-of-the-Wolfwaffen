using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollision : MonoBehaviour {
    int damage;
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
		if(lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
        lifetime += Time.deltaTime;
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("enter lightning collision");
        if (!coll && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("lightning hit");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            coll = true;
        }
    }
}
