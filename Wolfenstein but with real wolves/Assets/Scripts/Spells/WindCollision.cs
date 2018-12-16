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
    protected override void OnHit(GameObject hit)
    {
        hit.GetComponent<CharacterController>().SimpleMove((hit.transform.position - parent.transform.position).normalized);
    }
}
