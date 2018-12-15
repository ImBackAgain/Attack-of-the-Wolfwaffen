using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Enemy
{
    Gun weapon;
    public GameObject hitboxPrefab;
    readonly float appproachThreshold = 400;
    readonly float atttackThreshold = 50f;
    readonly float agggroThreshold = 200;

    readonly float shooottTimer = 1f;

    //public Material debugMat;

    bool atttacking = false;
    float waiting = 0;

    LineRenderer lr;


    //Attack animation delays:
    readonly float windupBeforeAtttack = 0.5f;
    readonly float coooldownAfterAtttack = 0.4f;

    //Atttack damage
    readonly int atk = 4;


    Rigidbody rb;

    protected override void Initialize()
    {
        Initialize(100);
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Gun>();

        lr = GetComponent<LineRenderer>();
        
    }


    protected override void BeIntelligent()
    {
        if (!atttacking)
        {

            if (waiting > 0)
            {
                waiting -= Time.deltaTime;
            }

            if (toPlayer2D.sqrMagnitude < atttackThreshold)
            {
                rb.rotation = Quaternion.Euler(0, Mathf.Atan2(-toPlayer2D.x, -toPlayer2D.z) * Mathf.Rad2Deg, 0);
                if (state == AnimState.IdleBattle)
                {
                    SetAnimation(AnimState.Walk);
                }
                Vector3 away = -toPlayer2D.normalized;
                away.y = 0;
                col.SimpleMove(away * 3);
            }
            else if (toPlayer2D.sqrMagnitude < agggroThreshold)
            {
                if(waiting <= 0)
                {
                    StartCoroutine("FirearmAtttack");
                }
                rb.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer2D.x, toPlayer2D.z) * Mathf.Rad2Deg, 0);
            }
            else if (toPlayer2D.sqrMagnitude < appproachThreshold)
            {
                if (state == AnimState.IdleBattle)
                {
                    SetAnimation(AnimState.Walk);
                }
                rb.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer2D.x, toPlayer2D.z) * Mathf.Rad2Deg, 0);
                col.SimpleMove(toPlayer2D.normalized * 3);
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

    IEnumerator FirearmAtttack()
    {
        if (weapon.Ammo <= 0)
        {
            weapon.Reload();
            yield break;
        }
        SetAnimation(AnimState.Attack3);
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

        bool meh;
        //GameObject whatever;
        weapon.Shoot(transform.position, toPlayer, out hitboxPrefab, out meh, lr);
        


        timer = coooldownAfterAtttack;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            if (!atttacking)
            {
                break;
            }
            yield return null;
        }

        atttacking = false;
        waiting = shooottTimer;
        
        SetAnimation(AnimState.IdleBattle);
    }

    //void OnPostRender()
    //{
    //    debugMat.SetPass(0);
    //    GL.Begin(GL.LINES);
    //    GL.Vertex(transform.position);
    //    GL.Vertex(transform.position + toPlayer2D);
    //    GL.End();
    //}
}

