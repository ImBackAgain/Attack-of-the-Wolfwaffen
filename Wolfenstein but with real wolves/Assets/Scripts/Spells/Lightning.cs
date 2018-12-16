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
    protected override void Initialize() {
        Initialize("Ventas Fulmino", 2);
        maxRange = 5f;
        aoe = 90f;
        cooldown = 5f;
        casted = false;
        cooldownTime = 0f;
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
    }

    protected override void DrawSpell()
    {
        createdObj = Instantiate(projectilePrefab);
        createdObj.transform.position = caster.transform.position;
        createdObj.transform.forward = caster.transform.forward;
    }
}
