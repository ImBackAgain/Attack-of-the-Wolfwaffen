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
    protected override void Initialize() {
        Initialize("Gravitus", 0, 5);

        duration = 5f;
        timer = 0f;
        activated = false;

        playerController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
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
        base.Update();
    }

    protected override void DrawSpell()
    {
        throw new System.NotImplementedException();
    }
}
