using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    bool open = false;
    public bool silverLocked;
    public bool goldLocked;
    bool inDoorWay = false; // whether or not the player is close to the door
    AudioSource openSFX = null;
    AudioSource closeSFX = null;
    AudioSource unlockSFX = null;
    AudioSource lockSFX = null;
    public Player p1;

	// Use this for initialization
	void Start ()
    {
        p1 = GameObject.Find("FPSController").GetComponent<Player>();
        AudioSource[] sounds = GetComponents<AudioSource>();
        if(sounds != null)
        {
            unlockSFX = sounds[0];
            lockSFX = sounds[1];
            closeSFX = sounds[2];
            openSFX = sounds[3];
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && inDoorWay)
        {
            if(silverLocked)
            {
                if(p1.gotSilver)
                {
                    unlockSFX.Play();
                    transform.Rotate(0, 0, 90);
                    openSFX.Play();
                    silverLocked = false;
                    open = !open;
                }

                else
                    lockSFX.Play();
            }

            else if(goldLocked)
            {
                if (p1.gotGold)
                {
                    unlockSFX.Play();
                    transform.Rotate(0, 0, 90);
                    openSFX.Play();
                    goldLocked = false;
                }

                else
                    lockSFX.Play();
            }

            else
            {
                if (open == false)
                {
                    transform.Rotate(0, 0, 90);
                    openSFX.Play();
                }
                else
                {
                    transform.Rotate(0, 0, -90);
                    closeSFX.Play();
                }
                open = !open;
            }
            
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            inDoorWay = true;         
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inDoorWay = false;
        }
    }
}
