using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Lifeform {
    bool gameOver = false;
    SceneEnd fader;
    Gun revolver;
    public AudioSource reload;
    public AudioSource grunt;
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

        fader = GameObject.Find("Fader").GetComponent<SceneEnd>();

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
        grunt = sounds[2];
    }

	
	// Update is called once per frame
	void Update () {

        if (gameOver)
        {
            return;
        }


        if (transform.position.y < -100)
        {
            health = 0;
        }

        if (health <= 0)
        {
            fader.StartTrans(3);
            gameOver = true;
        }


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

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            TakeDamage(-10);
        }

        if(evilBobRef == null)
        {
            //SceneManager.LoadScene(2);
            fader.StartTrans(2);
            gameOver = true;
        }
	}



    
}
