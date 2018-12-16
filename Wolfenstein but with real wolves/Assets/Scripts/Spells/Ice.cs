using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Spells {

    private float speed;
    private bool projectile;

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
        Initialize("Infriga", 3);
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        casted = false;
        cooldownTime = 0f;
        projectile = false;
        speed = 0.25f;
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
        if (createdObj == null)
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
        createdObj = Instantiate(projectilePrefab);
        createdObj.transform.position = caster.transform.position + caster.transform.forward;
        createdObj.transform.forward = caster.transform.forward;
        projectile = true;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "EnemyTag")
    //    {
    //        collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
    //    }
    //    Destroy(createdObj);
    //    projectile = false;
    //}
}
