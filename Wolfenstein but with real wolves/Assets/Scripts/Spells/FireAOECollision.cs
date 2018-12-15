using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAOECollision : MonoBehaviour {
    int damage;
	// Use this for initialization
	void Start () {
        damage = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("fire aoe collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
