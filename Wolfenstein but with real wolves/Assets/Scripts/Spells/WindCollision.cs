using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollision : MonoBehaviour {
    int damage;
	// Use this for initialization
	void Start () {
        damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("wind collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            //push back
        }
    }
}
