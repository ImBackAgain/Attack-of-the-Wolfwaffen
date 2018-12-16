using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Spells {


    private bool projectile;
    private float speed;

    public override void Cast()
    {
        if (!casted)
        {
            Debug.Log("Cast " + spellName);
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Fuego", 2, 10);
        aoe = 5f;
        cooldown = 5f;
        cooldownTime = 0f;
        casted = false;
        cooldownTime = 0f;
        speed = 0.25f;
        projectile = false;
        caster = gameObject;
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
        if(createdObj == null)
        {
            projectile = false;
        }
        if (projectile)
        {
            createdObj.transform.position += createdObj.transform.forward * speed;
        }
    }

    protected override void DrawSpell()
    {
        createdObj = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);
        createdObj.GetComponent<FireCollision>().SetDamage(damage, (float)damage / 2);
        projectile = true;
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.Log("fire collision");
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
    //    }
    //    Destroy(createdObj);
    //    projectile = false;
    //}
}
