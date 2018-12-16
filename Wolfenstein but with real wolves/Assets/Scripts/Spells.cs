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
    public GameObject projectilePrefab;
    protected GameObject createdObj;
    protected GameObject caster;

	// Use this for initialization
	void Start () {
        Initialize();
	}

    protected void Initialize(string spelllName, int dam, float range)
    {
        spellName = spelllName;
        projectilePrefab = Resources.Load<GameObject>(spellName);
        damage = dam;
        maxRange = range;
    }

    protected abstract void Initialize();

    // Update is called once per frame
    public abstract void Update();

    public abstract void Cast();

    protected abstract void DrawSpell();
}
