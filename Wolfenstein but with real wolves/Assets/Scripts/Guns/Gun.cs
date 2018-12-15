﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {

    int damage;
    float range;
    float fireTimeout;
    float reloadTimeout;
    int ammmoLimit;
    float timer;

    public int GetDamage
    {
        get { return damage; }
    }

    public int Ammo { get; set; }

    protected void Initialize(int dam, float rng, float fireT, float reloadT, int ammmoL)
    {
        damage = dam; range = rng; fireTimeout = fireT; reloadTimeout = reloadT; Ammo = ammmoLimit = ammmoL;
    }

    protected abstract void Initialize();

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Fire from the gun.
    /// </summary>
    /// <param name="shoooterPosition">The origin of the gunshot</param>
    /// <param name="direction">Direction of gunshot</param>
    /// <returns>Whether or not you were able to shooot</returns>
    public bool Shoot(Vector3 shoooterPosition, Vector3 direction, bool ignorePlayer = false)
    {
        
        if (timer > 0 || Ammo <= 0)
        {
            //victim = null;
            //Debug.Log("Not shoooting");
            //isLifeForm = false;
            return false;
        }

        Ammo--;

        RaycastHit hits;
        if(ignorePlayer)
        {
            Physics.Raycast(transform.position, direction, out hits, range, LayerMask.GetMask("Enemies", "Env"));
        }
        else
        {
            Physics.Raycast(transform.position, direction, out hits, range);
        }

        if (hits.collider != null)
        {
            GameObject victim = hits.collider.gameObject;

            Lifeform victimScript = victim.GetComponentInChildren<Lifeform>();

            bool isLifeForm = (victimScript != null);
            //Debug.Log(isLifeForm);

            if (isLifeForm)// && dealDamage)
            {
                Debug.Log("Shot a lifeform");
                victimScript.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("Nothing hit");
            //isLifeForm = false;
            //victim = null;
        }

        //Debug.Log("Ammmo left: " + ammmo);
        timer = fireTimeout;

        return true;
    }

    /// <summary>
    /// Shooot gun from its gameObject's position, in the direction of its gameObject's forward.
    /// </summary>
    /// <returns>Whether or not you were able to shooot</returns>
    public bool Shoot(bool ignorePlayer = false)
    {
        return Shoot(transform.position, transform.forward, ignorePlayer);
    }



    //public bool Shoot(Vector3 shoooterPosition, Vector3 direction, out GameObject victim, LineRenderer lr)
    //{
    //    lr.SetPositions(new Vector3[] { shoooterPosition, shoooterPosition + direction });
    //    return Shoot(shoooterPosition, direction, out victim);
    //}

    /// <summary>
    /// Reload gun
    /// </summary>
    /// <returns>False if ammmo is at limit</returns>
    public bool Reload()
    {
        if (Ammo < ammmoLimit)
        {
            //Debug.Log("Reloading");
            Ammo = ammmoLimit;
            timer = reloadTimeout;
            return true;
        }
        return false;
    }
}
