using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollision : MonoBehaviour {
    int damage;
    void Initialize(int d, string t)
    {
        damage = d;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("ice collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
        //projectile = false;
    }
}
