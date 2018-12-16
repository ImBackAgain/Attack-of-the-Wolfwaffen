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
        Initialize("Infriga", 3, 10, 5);
        projectile = false;
        speed = 0.25f;
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
        CreateProjectile();
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
