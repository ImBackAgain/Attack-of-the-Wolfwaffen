using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Spells {

    protected float duration;
    private float timer;
    private bool activated;
    private float speed;

    public override void Cast()
    {
        if (!casted)
        {
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    void Start () {
        name = "Ventus Servitas";
        damage = 1;
        maxRange = 3f;
        aoe = 3f;
        cooldown = 10f;
        obj = GameObject.Find("Wind");
        duration = 5f;
        casted = false;
        timer = 0f;
        activated = false;
        cooldownTime = 0f;
        speed = 0;
        player = this.gameObject;
    }

    // Update is called once per frame
    public override void Update ()
    {
        if (activated)
        {
            timer += Time.deltaTime;
            obj.transform.LookAt(player.transform);
            obj.transform.position += obj.transform.right * speed;
            if (timer >= duration)
            {
                Destroy(obj);
                activated = false;
            }
        }

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
        speed = 1;
        obj.transform.position = player.transform.position + player.transform.forward * 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            //push back
        }
    }
}
