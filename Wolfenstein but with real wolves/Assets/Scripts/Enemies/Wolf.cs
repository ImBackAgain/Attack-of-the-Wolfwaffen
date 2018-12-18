using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy {
    
    GameObject hitboxPrefab;
    readonly float atttackThreshold = 2f;
    readonly float agggroThreshold = 400;
    AudioSource deathSFX;



    bool atttacking = false;


    //Attack animation delays:
    readonly float windupBeforeAtttack = 0.5f;
    readonly float durationOfAtttack = 0.4f;    
    readonly float coooldownAfterAtttack = 0.4f;
    readonly float moveSpeeed = 3;

    //Atttack damage
    readonly int atk = 5;



    protected override void Initialize()
    {
        Initialize(10);
        hitboxPrefab = Resources.Load<GameObject>("Hitbox");
        deathSFX = GetComponent<AudioSource>();
    }


    protected override void BeIntelligent()
    {
        if (!atttacking)
        {
            if (toPlayer.sqrMagnitude < agggroThreshold)
            {
                if (name == "The first") Debug.Log("Rotating");
                transform.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer2D.x, toPlayer2D.z) * Mathf.Rad2Deg, 0);

                if (toPlayer2D.sqrMagnitude < atttackThreshold)
                {
                    StartCoroutine("ClawAttack");
                    //Debug.Log("Claw atttacked?");
                }
                else
                {
                    if (state == AnimState.IdleBattle)
                    {
                        SetAnimation(AnimState.Walk);
                    }
                    col.SimpleMove(toPlayer2D.normalized * moveSpeeed);
                }
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

    protected override void Die()
    {
        if(atttacking)
        {
            StopAllCoroutines();
        }
        deathSFX.Play();
        SetAnimation(AnimState.Death);
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
