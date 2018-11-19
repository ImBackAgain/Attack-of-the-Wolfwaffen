﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour {

    protected string name;
    protected int damage;
    protected float maxRange;
    protected float aoe;
    protected float cooldown;
    protected GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected abstract void Cast();
}
