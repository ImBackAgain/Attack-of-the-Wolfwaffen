using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {
    
    int damage;
    float dotDamage;
    public GameObject fireAOE;
    GameObject createdObj;
    string targetTag;
	
    public void Initialize(int d, float ad, string t)
    {
        damage = d;
        //Debug.Log("It reallly is " + damage);
        dotDamage = ad;
        fireAOE = Resources.Load<GameObject>("FireAOECollision");
        targetTag = t;
    }

	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("fire collision with ..." + collision.gameObject + "?");
        if (collision.gameObject.tag == targetTag)
        {
            //Debug.Log("Dealing " + damage + " to an enemy.");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        createdObj = Instantiate(fireAOE, transform.position, Quaternion.identity);
        createdObj.GetComponent<FireAOECollision>().SetDamage(dotDamage);
        Destroy(gameObject);
    }
}
