using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollision : MonoBehaviour {
    int damage;
	// Use this for initialization
	void Start () {
        damage = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("ice collision");
        if (collision.gameObject.tag == "EnemyTag")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
        //projectile = false;
    }
}
