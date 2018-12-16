using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour {

    protected string spellName;
    protected string targetTag;
    protected int damage;
    protected float maxRange;
    protected float cooldown;
    protected bool casted;
    protected float cooldownTime;
    public GameObject projectilePrefab;
    protected GameObject createdObj;
    protected Lifeform caster;
    protected Transform CastForm
    {
        get { return caster.transform; }
    }
    protected Vector3 CasterForward
    {
        get { return caster.Forward; }
    }

	// Use this for initialization
	void Start () {
        Initialize();
	}

    public void SetTargets(string tag)
    {
        targetTag = tag;
    }

    protected void Initialize(string spelllName, int dam, float range, float coooldown)
    {
        spellName = spelllName;
        projectilePrefab = Resources.Load<GameObject>(spellName);
        damage = dam;
        maxRange = range;

        cooldown = coooldown;
        cooldownTime = 0;
        casted = false;

        caster = GetComponent<Lifeform>();
    }

    protected abstract void Initialize();

    // Update is called once per frame
    public abstract void Update();

    public abstract void Cast();

    protected abstract void DrawSpell();

    protected void CreateProjectile()
    {
        createdObj = Instantiate(projectilePrefab, CastForm.position + CasterForward, CastForm.rotation);
        createdObj.transform.forward = CasterForward;
    }
}
