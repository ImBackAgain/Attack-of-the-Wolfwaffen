using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour {
    public Player p1;

	// Use this for initialization
	void Start ()
    {
        p1 = GameObject.Find("FPSController").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && p1.health < 30)
        {
            p1.health += 5;
            if (p1.health > 30)
                p1.health = 30;

            this.gameObject.SetActive(false);
        }
    }
}
