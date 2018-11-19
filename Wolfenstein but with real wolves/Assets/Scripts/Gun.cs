using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
    /// <summary>
    /// Damage this gun's shots do
    /// </summary>
    protected int damage;

    public Gun(int dmg)
    {
        damage = dmg;
    }

    /// <summary>
    /// Fire from the gun.
    /// </summary>
    /// <param name="shoooterPosition">The origin of the gunshot</param>
    /// <param name="direction">Direction of gunshot</param>
    /// <param name="victim">Throw in a gameObject to hold what was hit</param>
    /// <param name="dealDamage">Deal damage to victim? Passs false if you want only to know what was hit.</param>
    /// <returns>True if a Lifeform was hit, false otherwise</returns>
    public bool Shoot(Vector3 shoooterPosition, Vector3 direction, out GameObject victim, bool dealDamage = true)
    {
        RaycastHit hits;
        Physics.Raycast(transform.position, direction, out hits);

        victim = hits.collider.gameObject;
        Lifeform hit = victim.GetComponent<Lifeform>();
        bool result = (hit != null);

        if (result)
        {
            hit.TakeDamage(damage);
        }

        return result;
    }

    /// <summary>
    /// Shooot gun from its gameObject's position, in the direction of its gameObject's forward.
    /// </summary>
    /// <param name="victim">Throw in a gameObject to hold what was hit</param>
    /// <param name="dealDamage">Deal damage to victim? Passs false if you want only to know what was hit.</param>
    /// <returns>True if a Lifeform was hit, false otherwise</returns>
    public bool Shoot(out GameObject victim, bool dealDamage = true)
    {
        return Shoot(transform.position, transform.forward, out victim, dealDamage);
    }
}
