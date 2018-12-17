using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobButEvil : Enemy {

    Vector3 forward;

    float timer;
    float waitTime;

    bool dormant = true;

    public void Awaken()
    {
        dormant = false;
    }

    Dictionary<string, Spells> spells;

    enum Action { Fire, Ice, Lightning };

    Action toDo;

    public override Vector3 Forward
    {
        get
        {
            return forward;
        }
    }

    protected override void Initialize()
    {
        //Health display
        healthOfffset = 0.7f;
        healthScalar = 0.128f / transform.localScale.x;


        Initialize(50);
        spells = new Dictionary<string, Spells>
        {
            { "Fire", GetComponent<Fire>() },
            { "Ice", GetComponent<Ice>() },
            { "Lightning", GetComponent<Lightning>() },
            { "Booom", GetComponent<Booom>() }
        };

        foreach (string name in spells.Keys)
        {
            spells[name].SetTargets("Player");
        }

        DecideOnNextAction();
    }

    protected override void BeIntelligent()
    {
        if (dormant) return;

        timer += Time.deltaTime;
        forward = toPlayer - Vector3.Dot(toPlayer, transform.right) * transform.right;
        forward.Normalize();

        rb.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer2D.x, toPlayer2D.z) * Mathf.Rad2Deg, 0);


        if(Input.GetKeyDown(KeyCode.Z))
        {
            spells["Booom"].Cast();
        }

        if (timer >= 3)
        {
            timer -= 3;
            //spells["Fire"].Cast();
        }
    }
    
    void DecideOnNextAction()
    {
        toDo = (Action)Random.Range(0, 3);
    }
}
