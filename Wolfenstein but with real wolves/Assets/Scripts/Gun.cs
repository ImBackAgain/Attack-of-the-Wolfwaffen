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
    /// Fire from the gun
    /// </summary>
    /// <param name="direction">What direction it's firing.</param>
    /// <param name="dealDamage">Whether or not to deal damage. Use false if you want to, uh, find out what it would hit?</param>
    /// <returns></returns>
    public GameObject Shoot(Vector3 direction, bool dealDamage = true)
    {
        RaycastHit hits;
        Physics.Raycast(transform.position, direction, out hits);

        return gameObject;
    }
}
