//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobButEvil : Enemy {
    float timer;
    float waitTime;

    readonly float overtimeDuration = 3;

    readonly float buffferTime = 3;

    public Bounds realm;

    readonly float squareDangerRadius = Mathf.Pow(2.3f, 2);
    readonly float squareLightningRange = Mathf.Pow(4, 2);

    bool dormant = true;

    float wanderTimer;
    readonly float wanderDelay = 1;

    Vector3 direction;


    enum Action { Fire, Ice, Lightning, Booom };

    Action toDo;
    readonly float speeed = 10;

    Dictionary<string, Spells> spells;

    Vector3 forward;
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
        wanderTimer = wanderDelay;
    }
    
    public void Awaken()
    {
        if (dormant)
        {
            dormant = false;
            DecideOnNextAction();
        }
    }


    protected override void BeIntelligent()
    {
        if (dormant) return;

        timer += Time.deltaTime;
        forward = toPlayer - Vector3.Dot(toPlayer, transform.right) * transform.right;
        forward.Normalize();
        transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.up);

        DangerCast();

        if (waitTime > timer)
        {
            wanderTimer += Time.deltaTime;
            if (wanderTimer < wanderDelay)
            {
                transform.position += direction * Time.deltaTime;
            }
            else
            {
                wanderTimer -= wanderDelay;
                direction = Random.onUnitSphere;
                direction.Normalize();
            }
        }
        else
        {
            if (timer < waitTime + overtimeDuration)
            {
                switch (toDo)
                {
                    case Action.Booom:
                        transform.position += toPlayer.normalized * speeed * Time.deltaTime;
                        break;

                    case Action.Lightning:
                        transform.position += toPlayer.normalized * speeed * Time.deltaTime;
                        if (toPlayer.sqrMagnitude < squareLightningRange)
                        {
                            spells["Lightning"].Cast();
                            DecideOnNextAction();
                        }
                        break;

                    case Action.Fire:
                    case Action.Ice:
                    default:
                        //Debug.Log("Bob cast a spelll");
                        spells[toDo.ToString()].Cast();
                        DecideOnNextAction();
                        break;
                }
            }
            else
            {
                DecideOnNextAction();
            }
        }

        StayInBounds();

    }

    private void StayInBounds()
    {
        if (!realm.Contains(transform.position))
        {
            transform.position = realm.ClosestPoint(transform.position);
        }
    }

    void DecideOnNextAction()
    {
        timer = 0;
        if(spells["Booom"].TimeLeft <= 0 && Random.Range(0, 10) > 8)
            //If the spelll is ready, 10% chance he'lll just come at you
        {
            toDo = Action.Booom;
        }
        else
        {
            toDo = (Action)Random.Range(0, 3);
        }
        waitTime = Mathf.Max(spells[toDo.ToString()].TimeLeft, buffferTime);
    }

    void DangerCast()
    {
        if (toDo == Action.Booom)
        {
            DecideOnNextAction();
        }
        if (toPlayer2D.sqrMagnitude < squareDangerRadius)
        {
            spells["Booom"].Cast();
        }
    }
}
