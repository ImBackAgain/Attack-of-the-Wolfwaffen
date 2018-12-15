using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {
    
    int damage;
    public GameObject fireAOE;
    GameObject createdObj;
	// Use this for initialization
	void Start () {
        damage = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("fire collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            createdObj = Instantiate(fireAOE);
            createdObj.transform.position = gameObject.transform.position;
        }
        Destroy(gameObject);
    }
}
