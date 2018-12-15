using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Spells {
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
    void Start () {
        obj = GameObject.Find("Lightning");
        spellName = "Ventas Fulmino";
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
        createdObj.transform.forward = player.transform.forward;
    }
}
