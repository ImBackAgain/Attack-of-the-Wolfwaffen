using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour {

    protected string spellName;
    protected int damage;
    protected float maxRange;
    protected float aoe;
    protected float cooldown;
    protected bool casted;
    protected float cooldownTime;
    protected GameObject obj;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected virtual void Update()
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

    public abstract void Cast();
}
