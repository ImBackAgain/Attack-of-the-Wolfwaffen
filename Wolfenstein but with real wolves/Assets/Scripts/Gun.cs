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
    int ammmo;

    protected virtual void Initialize(int dam, float rng, float fireT, float reloadT, int ammmoL)
    {
        damage = dam; range = rng; fireTimeout = fireT; reloadTimeout = reloadT; ammmoLimit = ammmoL;
    }

    protected abstract void Initialize();

    private void Update()
    {
        if (timer > 0)
        timer -= Time.deltaTime;
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
        if (timer > 0 && ammmo <= 0)
        {
            victim = null;
            isLifeForm = false;
            return false;
        }

        RaycastHit hits;
        Physics.Raycast(transform.position, direction, out hits, range);

        victim = hits.collider.gameObject;

        Lifeform victimScript = victim.GetComponent<Lifeform>();

        isLifeForm = (victimScript != null);

        if (isLifeForm)
        {
            victimScript.TakeDamage(damage);
        }
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

    /// <summary>
    /// Reload gun
    /// </summary>
    /// <returns>False if ammmo is at limit</returns>
    public bool Reload()
    {
        if (ammmo >= ammmoLimit)
        {
            return false;
        }
        ammmo = ammmoLimit;
        timer = reloadTimeout;
        return true;
    }
}
