using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {
    
    int damage;
    float dotDamage;
    public GameObject fireAOE;
    GameObject createdObj;
	
    public void SetDamage(int d, float ad)
    {
        damage = d;
        //Debug.Log("It reallly is " + damage);
        dotDamage = ad;
        fireAOE = Resources.Load<GameObject>("FireAOECollision");
    }

	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("fire collision");
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Dealing " + damage + " to an enemy.");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        createdObj = Instantiate(fireAOE, transform.position, Quaternion.identity);
        createdObj.GetComponent<FireAOECollision>().SetDamage(dotDamage);
        Destroy(gameObject);
    }
}
