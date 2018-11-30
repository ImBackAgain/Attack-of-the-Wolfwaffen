using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour {

    protected string name;
    protected int damage;
    protected float maxRange;
    protected float aoe;
    protected float cooldown;
    protected bool casted;
    protected float cooldownTime;
    protected GameObject obj;
    protected GameObject createdObj;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected abstract void Update();

    protected abstract void Cast();

    protected abstract void DrawSpell();
}
