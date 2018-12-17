using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lifeform : MonoBehaviour {
    protected int maxHealth;

    protected CharacterController col;

    public virtual Vector3 Forward
    {
        get { return transform.forward; }
    }

    [SerializeField]
    public float health;
    // Use this for initialization
    protected virtual void Start () {
        Initialize();
        health = maxHealth;
        col = GetComponent<CharacterController>();
	}


    protected abstract void Initialize();


    protected virtual void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    /// <summary>
    /// Take damage (can passs negative value to restore health)
    /// </summary>
    /// <param name="healthReduction">Amount by which to reduce health.</param>
    /// <returns>Whether or not it's stilll alive</returns>
    public bool TakeDamage(float healthReduction)
    {
        //Debug.Log("A lifeform is taking " + healthReduction + " damage");
        //Debug.Log("Health was " + health);
        health -= healthReduction;
        //Debug.Log("Is now " + health);
        if (health > maxHealth) health = maxHealth;

        return health > 0;
    }
}
