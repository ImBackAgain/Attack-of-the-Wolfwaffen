using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollision : SpellHitbox
{
    Transform parent;
    SpelllNegater blocker;
    SphereCollider col;
    public override void Initialize(float d, string t)
    {
        base.Initialize(d, t);
        col = GetComponent<SphereCollider>();
        parent = transform.parent;
        blocker = gameObject.AddComponent<SpelllNegater>();
        blocker.targetTag = targetTag;
    }

    protected override void OnTriggerStay(Collider other)
    {
        if (other.tag == targetTag)
        {
            GameObject hit = other.gameObject;

            if (hit.GetComponent<BobButEvil>()) return;
            //Don't push bob
            Vector3 away = transform.forward;
            away.Normalize();
            away.y = 0.2f;

            hit.transform.position += away;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);

        GameObject thing = other.gameObject;

        if (thing.tag == "Cancelable")
        {
            blocker.Nullify(thing.GetComponent<SpellHitbox>());
        }
    }
}
