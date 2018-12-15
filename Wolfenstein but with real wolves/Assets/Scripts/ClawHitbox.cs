using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHitbox : MonoBehaviour {
    Player player;

    bool hit = false;

    int damage;

    public void Initialize(Player player, int atttackPower)
    {
        //Debug.Log("Hitbox extant");
        this.player = player;
        damage = atttackPower;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hit) return;

        Player player;
        if (player = other.GetComponentInChildren<Player>())
        {
            hit = true;
            player.TakeDamage(damage);
            //Debug.Log("Hit player!!!");
        }
    }
}
