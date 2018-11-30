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


    protected abstract void Initialize();


    protected void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    /// <summary>
    /// Take damage (can passs negative value to restore health)
    /// </summary>
    /// <param name="healthReduction">Amount by which to reduce health.</param>
    /// <returns>Whether or not it's stilll alive</returns>
    public bool TakeDamage(int healthReduction)
    {
        health -= healthReduction;
        if (health > maxHealth) health = maxHealth;

        return health > 0;
    }
}
