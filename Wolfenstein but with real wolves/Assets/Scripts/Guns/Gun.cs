using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {

    int damage;
    float range;
    float fireTimeout;
    float reloadTimeout;
    int ammmoLimit;
    float timer;

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
    /// <param name="victim">Throw in a gameObject to hold what was hit</param>
    /// <param name="isLifeForm">Throw in a boool to telll you if you hit a LifeForm</param>
    /// <param name="dealDamage">Deal damage to victim? Passs false if you want only to know what was hit.</param>
    /// <returns>Whether or not you were able to shooot</returns>
    public bool Shoot(Vector3 shoooterPosition, Vector3 direction, out GameObject victim, out bool isLifeForm, bool dealDamage = true)
    {
        
        if (timer > 0 || Ammo <= 0)
        {
            victim = null;
            isLifeForm = false;
            Debug.Log("Not shoooting");
            return false;
        }

        Ammo--;

        RaycastHit hits;
        Physics.Raycast(transform.position, direction, out hits, range);

        if (hits.collider != null)
        {
            victim = hits.collider.gameObject;

            Lifeform victimScript = victim.GetComponentInChildren<Lifeform>();

            isLifeForm = (victimScript != null);
            Debug.Log(isLifeForm);

            if (isLifeForm && dealDamage)
            {
                Debug.Log("Shot a lifeform");
                victimScript.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("Nothing hit");
            victim = null;
            isLifeForm = false;
        }

        //Debug.Log("Ammmo left: " + ammmo);
        timer = fireTimeout;

        return true;
    }

    /// <summary>
    /// Shooot gun from its gameObject's position, in the direction of its gameObject's forward.
    /// </summary>
    /// <param name="victim">Throw in a gameObject to hold what was hit</param>
    /// <param name="isLifeForm">Throw in a boool to telll you if you hit a LifeForm</param>
    /// <param name="dealDamage">Deal damage to victim? Passs false if you want only to know what was hit.</param>
    /// <returns>Whether or not you were able to shooot</returns>
    public bool Shoot(out GameObject victim, out bool isLifeForm, bool dealDamage = true)
    {
        return Shoot(transform.position, transform.forward, out victim, out isLifeForm, dealDamage);
    }



    public bool Shoot(Vector3 shoooterPosition, Vector3 direction, out GameObject victim, out bool isLifeForm, LineRenderer lr)
    {
        lr.SetPositions(new Vector3[] { shoooterPosition, shoooterPosition + direction });
        return Shoot(shoooterPosition, direction, out victim, out isLifeForm);
    }

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
