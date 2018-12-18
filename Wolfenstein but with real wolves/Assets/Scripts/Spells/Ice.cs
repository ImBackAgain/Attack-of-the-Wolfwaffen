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
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Infriga", 3, 5);
        projectile = false;
        speed = 0.25f;
    }
	
	

    protected override void DrawSpell()
    {
        CreateProjectile();
        createdObj.GetComponent<IceCollision>().Initialize(damage, targetTag);
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
