﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Lifeform {
    Gun revolver;
    AudioSource reload;
    public GameObject evilBobRef;

    public Transform child;

    public override Vector3 Forward
    {
        get
        {
            return child.forward;
        }
    }
    public bool gotGold = false;
    public bool gotSilver = false;
    public float HealthRatio
    {
        get { return health / maxHealth; }
    }

    public int AmmoLeft
    {
        get { return revolver.Ammo; }
    }

    public Dictionary<string, Spells> spells = new Dictionary<string, Spells>();

    protected override void Initialize()
    {
        Initialize(30);
        revolver = GetComponent<Gun>();

        spells.Add("Fire", GetComponent<Fire>());
        spells.Add("Force", GetComponent<Force>());
        spells.Add("Gravity", GetComponent<Gravity>());
        spells.Add("Ice", GetComponent<Ice>());
        spells.Add("Lightning", GetComponent<Lightning>());
        spells.Add("Wind", GetComponent<Wind>());

        foreach(string name in spells.Keys)
        {
            spells[name].SetTargets("Enemy");
        }

        child = GetComponentsInChildren<Transform>()[1];
        AudioSource[] sounds = GetComponents<AudioSource>();
        reload = sounds[1];
    }

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire gun"))
        {
            revolver.Shoot(transform.position, Forward, true);
        }

        if (Input.GetButtonDown("Reload gun"))
        {
            revolver.Reload();
            reload.Play();
        }

        foreach(string spelllName in spells.Keys)
        {
            if (Input.GetButtonDown("Cast" + spelllName))
            {
                spells[spelllName].Cast();
            }
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(3);
        }

        if(evilBobRef == null)
        {
            SceneManager.LoadScene(2);
        }
	}



    
}
