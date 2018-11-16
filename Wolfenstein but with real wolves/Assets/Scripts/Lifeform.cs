using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lifeform : MonoBehaviour {
    protected int maxHealth;
    protected int health;
	// Use this for initialization
	void Start () {
        Initialize();
        health = maxHealth;
	}

    /// <summary>
    /// Set maxHealth, please.
    /// </summary>
    protected abstract void Initialize();


    // Update is called once per frame
    void Update () {
		
	}
}
