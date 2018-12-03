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
    void Start () {
        name = "Infriga";
        damage = 3;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        obj = GameObject.Find("Ice");
        casted = false;
        cooldownTime = 0f;
        projectile = false;
        speed = 0;
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
        if(projectile)
        {
            obj.transform.position += obj.transform.forward * speed;
        }
    }

    protected override void DrawSpell()
    {
        createdObj = Instantiate(obj);
        obj.transform.position = player.transform.position;
        obj.transform.forward = player.transform.forward;
        speed = 1;
        projectile = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyTag")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(createdObj);
        projectile = false;
    }
}
