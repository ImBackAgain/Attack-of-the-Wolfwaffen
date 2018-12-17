using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollision : SpellHitbox
{
    Transform parent;
    public override void Initialize(float d, string t)
    {
        base.Initialize(d, t);
        parent = transform.parent;
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        GameObject hit = other.gameObject;
        if (hit.tag == "Cancelable")
        {
            Destroy(other.gameObject);
        }
        else if (hit.tag == targetTag)
        {
            Vector3 away = (hit.transform.position - parent.transform.position);
            away.Normalize();
            away.y = 1;

            hit.transform.position += away;
        }
    }
}
