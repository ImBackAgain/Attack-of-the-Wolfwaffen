using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : SpellHitbox
{
    float dotDamage;
    public GameObject fireAOE;
    GameObject createdObj;

    float speeed;

    public void Initialize(float d, float ad, string t)
    {
        Initialize(d, t);
        dotDamage = ad;
        fireAOE = Resources.Load<GameObject>("FireAOECollision");
        speeed = 0.25f;
    }

    void Update()
    {
        transform.position += transform.forward * speeed;
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.tag == "Canceler") return;
        createdObj = Instantiate(fireAOE, transform.position, Quaternion.identity);
        createdObj.GetComponent<FireAOECollision>().SetDamage(dotDamage);
        Destroy(gameObject);
    }
}
