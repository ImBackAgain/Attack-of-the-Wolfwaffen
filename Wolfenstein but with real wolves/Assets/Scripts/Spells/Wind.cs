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
            Debug.Log("Cast " + spellName);
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    void Start () {
        spellName = "Ventus Servitas";
        damage = 1;
        maxRange = 3f;
        aoe = 3f;
        cooldown = 10f;
        duration = 5f;
        casted = false;
        timer = 0f;
        activated = false;
        cooldownTime = 0f;
        speed = 0.15f;
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
        if (activated)
        {
            timer += Time.deltaTime;
            createdObj.transform.LookAt(player.transform);
            createdObj.transform.position += createdObj.transform.right * speed;
            if (timer >= duration)
            {
                Destroy(createdObj);
                activated = false;
            }
        }
    }

    protected override void DrawSpell()
    {
        createdObj = Instantiate(obj);
        createdObj.transform.parent = player.transform;
        createdObj.transform.position = player.transform.position + player.transform.forward;
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
