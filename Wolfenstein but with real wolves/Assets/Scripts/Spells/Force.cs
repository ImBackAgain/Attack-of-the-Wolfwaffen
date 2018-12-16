using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            //Debug.Log("Force");
            casted = true;
            cooldownTime = 0f;
            //Raycast collision detection
            //Deal effect on hit
            RaycastHit hits;
            Physics.Raycast(caster.transform.position, caster.transform.forward, out hits);
            Enemy enemy;
            
            if(enemy = hits.collider.gameObject.GetComponent<Enemy>())
            {

                enemy.TakeDamage(damage);
            }
            
            //push back
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Assantius", 1, 10, 5);
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
