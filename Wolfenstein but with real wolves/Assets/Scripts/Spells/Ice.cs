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
    void Start () {
        spellName = "Infriga";
        damage = 3;
        maxRange = 10f;
        aoe = 0f;
        cooldown = 5f;
        obj = GameObject.Find("Ice");
        casted = false;
        cooldownTime = 0f;
        projectile = false;
        speed = 0;
    }
	
	// Update is called once per frame
	protected override void Update ()
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
            //Check collision
            //Deal damage on collision and remove projectile
            //projectile = false;
        }
    }

    protected override void DrawSpell()
    {
        obj.transform.position = player.transform.position;
        obj.transform.forward = player.transform.forward;
        speed = 1;
        projectile = true;
    }
}
