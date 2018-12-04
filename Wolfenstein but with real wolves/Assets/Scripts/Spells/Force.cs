using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
            //Raycast collision detection
            //Deal effect on hit
            RaycastHit hits;
            Physics.Raycast(player.transform.position, player.transform.forward, out hits);
            Enemy enemy = hits.collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            //push back
        }
    }

    // Use this for initialization
    void Start () {
        name = "Assantius";
        damage = 1;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        casted = false;
        cooldownTime = 0f;
        player = this.gameObject;
    }

    // Update is called once per frame
    public override void Update ()
    {
        if (casted)
        {
            cooldownTime += Time.deltaTime;
            if (cooldownTime >= cooldown)
            {
                casted = false;
            }
        }
    }

    protected override void DrawSpell()
    {
        throw new System.NotImplementedException();
    }
}
