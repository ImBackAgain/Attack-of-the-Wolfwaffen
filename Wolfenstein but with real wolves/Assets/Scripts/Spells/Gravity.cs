using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Gravity : Spells {

    protected float duration;
    private float timer;
    private bool activated;
    private FirstPersonController playerController;

    public override void Cast()
    {
        if(!casted)
        {
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
            //modify jump
            playerController.m_GravityMultiplier = 1.5f;
        }
    }

    // Use this for initialization
    void Start () {
        name = "Gravitus";
        damage = 0;
        maxRange = 0f;
        aoe = 0f;
        cooldown = 10f;
        duration = 5f;
        casted = false;
        timer = 0f;
        activated = false;
        cooldownTime = 0f;
        playerController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        player = this.gameObject;
    }

    // Update is called once per frame
    public override void Update ()
    {
		if(activated)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                activated = false;
                //modify jump
                playerController.m_GravityMultiplier = 2.5f;
            }
        }

        if(casted)
        {
            cooldownTime += Time.deltaTime;
            if(cooldownTime >= cooldown)
            {
                casted = false;

            }
        }
	}

    protected override void DrawSpell()
    {
        throw new System.NotImplementedException();
    }
}
