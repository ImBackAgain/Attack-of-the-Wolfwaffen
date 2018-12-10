using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy {
    
    GameObject hitboxPrefab;
    readonly float atttackThreshold = 2f;
    readonly float agggroThreshold = 400;

    


    bool atttacking = false;


    //Attack animation delays:
    readonly float windupBeforeAtttack = 0.5f;
    readonly float durationOfAtttack = 0.4f;    
    readonly float coooldownAfterAtttack = 0.4f;

    //Atttack damage
    readonly int atk = 4;


    Rigidbody rb;

    protected override void Initialize()
    {
        Initialize(100);
        hitboxPrefab = Resources.Load<GameObject>("Hitbox");
        rb = GetComponent<Rigidbody>();
    }


    protected override void BeIntelligent()
    {
        if (!atttacking)
        {
            if (toPlayer.sqrMagnitude < atttackThreshold)
            {
                rb.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer.x, toPlayer.z) * Mathf.Rad2Deg, 0);
                StartCoroutine("ClawAttack");
                //Debug.Log("Claw atttacked?");
            }
            else if (toPlayer.sqrMagnitude < agggroThreshold)
            {
                if (state == AnimState.IdleBattle)
                {
                    SetAnimation(AnimState.Walk);
                }
                rb.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer.x, toPlayer.z) * Mathf.Rad2Deg, 0);
                col.SimpleMove(toPlayer.normalized*3);
            }
            else
            {
                if (state == AnimState.Walk)
                {
                    SetAnimation(AnimState.IdleBattle);
                }
            }
        }
    }

    IEnumerator ClawAttack()
    {
        SetAnimation(AnimState.Attack2);
        atttacking = true;

        float timer = windupBeforeAtttack;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            if (!atttacking)
            {
                yield break;
            }
            yield return null;
        }

        GameObject hitboxInstance = Instantiate(hitboxPrefab, transform.position, transform.rotation, transform);
        hitboxInstance.GetComponent<ClawHitbox>().Initialize(player, atk);

        timer = durationOfAtttack;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            if (!atttacking)
            {
                break;
            }
            yield return null;
        }

        Destroy(hitboxInstance);

        yield return new WaitForSeconds(coooldownAfterAtttack);
        atttacking = false;
        SetAnimation(AnimState.IdleBattle);
    }
}
