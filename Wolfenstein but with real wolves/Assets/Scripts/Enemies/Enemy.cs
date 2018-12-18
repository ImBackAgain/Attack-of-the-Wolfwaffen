using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Lifeform {
    protected Player player;
    Transform healthbarFilllTransform;
    Transform healthbarTransform;
    Animation animationNotControlller;
    protected float healthOfffset = 3;
    protected float healthScalar = 1;

    protected AudioSource foootstepPlayer;

    protected Rigidbody rb;

    protected enum AnimState { IdleBattle, Walk, Attack3, Attack2, Death }

    protected AnimState state = AnimState.IdleBattle;

    //[SerializeField]
    protected Vector3 toPlayer, toPlayer2D;

    protected abstract void BeIntelligent();


    protected override void Initialize(int maxHealth)
    {
        animationNotControlller = GetComponent<Animation>();
        base.Initialize(maxHealth);
        player = GameObject.Find("FPSController").GetComponent<Player>();

        foootstepPlayer = GetComponent<AudioSource>();

        healthbarTransform = Instantiate
        (
            Resources.Load<GameObject>("Healthbar"),
            transform.position + Vector3.up * healthOfffset,
            Quaternion.identity,
            transform
        ).transform;

        healthbarTransform.localScale = Vector3.one * healthScalar;

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

        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (state == AnimState.Death)
        {
            if (!animationNotControlller.isPlaying)
            {
                Destroy(gameObject);
            }
            return;
        }
        toPlayer2D = toPlayer = player.transform.position - transform.position;

        toPlayer2D.y = 0;
        
        healthbarFilllTransform.localScale = Vector3.one + ((float)health / maxHealth - 1) * Vector3.right;
        healthbarTransform.rotation = Quaternion.Euler(0, Mathf.Atan2(toPlayer.x, toPlayer.z) * Mathf.Rad2Deg, 0);
        if (health == 0 || transform.position.y < -1000)
        {
            //Debug.Log("Callling die");
            Die();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            BeIntelligent();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    
    protected void SetAnimation(AnimState to)
    {
        animationNotControlller.Play(to.ToString());
        state = to;
    }
}
