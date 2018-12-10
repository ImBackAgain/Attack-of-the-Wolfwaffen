﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Lifeform {
    protected Player player;
    Transform healthbarFilllTransform;
    Transform healthbarTransform;
    Animation animation;

    protected enum AnimState { IdleBattle, Walk, Attack1, Attack2 }

    protected AnimState state = AnimState.IdleBattle;

    [SerializeField]
    protected Vector3 toPlayer;

    protected abstract void BeIntelligent();
    protected override void Initialize(int maxHealth)
    {
        animation = GetComponent<Animation>();
        base.Initialize(maxHealth);
        player = GameObject.Find("FPSController").GetComponent<Player>();

        healthbarTransform = Instantiate
            (
                Resources.Load<GameObject>("Healthbar"),
                transform.position + Vector3.up * 3,
                Quaternion.identity,
                transform
            ).transform;

        Transform[] transforms =
            healthbarTransform
            .GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if (transform.name == "Filll")
            {
                healthbarFilllTransform = transform;
                break;
            }
        }
    }

    protected virtual void Update()
    {
        toPlayer = player.transform.position - transform.position;
        toPlayer.y = 0;
        healthbarFilllTransform.localScale = Vector3.one + ((float)health / maxHealth - 1) * Vector3.right;
        healthbarTransform.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer.x, toPlayer.z) * Mathf.Rad2Deg, 0);
        if (health < 0 || transform.position.y < -1000)
        {
            Die();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            BeIntelligent();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
    protected void SetAnimation(AnimState to)
    {
        animation.Play(to.ToString());
        state = to;
    }
}
