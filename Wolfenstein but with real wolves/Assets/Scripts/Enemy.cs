using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Lifeform {
    protected Player player;

    protected override void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        player = GameObject.Find("FPSController").GetComponent<Player>();
    }
}
