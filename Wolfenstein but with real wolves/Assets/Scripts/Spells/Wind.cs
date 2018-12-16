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
    protected override void Initialize() {
        Initialize("Ventus Servitas", 1, 3, 10);
        duration = 5f;
        timer = 0f;
        activated = false;
        speed = 0.15f;
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
            createdObj.transform.LookAt(CastForm);
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
        createdObj = Instantiate(projectilePrefab, CastForm.position, CastForm.rotation, CastForm);
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
