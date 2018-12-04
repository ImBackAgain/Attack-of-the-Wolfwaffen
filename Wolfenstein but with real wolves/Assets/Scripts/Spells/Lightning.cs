using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
    public override void Cast()
    {
        if (!casted)
        {
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
            Destroy(createdObj);
        }
    }

    // Use this for initialization
    void Start () {
        name = "Ventas Fulmino";
        damage = 2;
        maxRange = 5f;
        aoe = 90f;
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
        createdObj = Instantiate(obj);
        createdObj.transform.position = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
