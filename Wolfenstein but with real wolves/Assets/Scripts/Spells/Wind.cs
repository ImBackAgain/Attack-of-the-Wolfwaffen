using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Spells {

    protected float duration;
    private float timer;
    private bool activated;
    private float speed;

    GameObject[] createdObjs;

    public override void Cast()
    {
        if (!casted)
        {
            //Debug.Log("Cast " + spellName);
            activated = true;
            timer = 0f;
            casted = true;
            cooldownTime = 0f;
            DrawSpell();
        }
    }

    // Use this for initialization
    protected override void Initialize() {
        Initialize("Ventus Servitas", 0.3f, 10);
        duration = 5f;
        timer = 0f;
        activated = false;
        speed = 0.15f;
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        if (activated)
        {
            timer += Time.deltaTime;
            foreach(GameObject createdObj in createdObjs)
            {
                createdObj.transform.LookAt(CastForm);
                createdObj.transform.position += createdObj.transform.right * speed;
            }
            if (timer >= duration)
            {
                foreach(GameObject createdObj in createdObjs)
                {
                    Destroy(createdObj);    
                }
                activated = false;
            }
        }
    }

    protected override void DrawSpell()
    {
        createdObjs = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            GameObject createdObj = Instantiate(projectilePrefab, CastForm.position, Quaternion.Euler(0, i * 120, 0), CastForm);
            createdObj.GetComponent<WindCollision>().Initialize(damage, targetTag);

            createdObjs[i] = createdObj;
        }
    }

}
