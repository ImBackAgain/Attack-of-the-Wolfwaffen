using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAOECollision : MonoBehaviour {
    float damage;
    readonly float lifespan = 2f;
    float timer = 0;

    Material mat;

	// Use this for initialization
	public void SetDamage(float damage)
    {
        this.damage = damage;
        mat = GetComponent<MeshRenderer>().material;
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

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("fire aoe collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
