using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isGold;
    public bool isSilver;
    bool GoldGet = false;
    bool SilverGet = false;
    public Player p1;
	// Use this for initialization
	void Start ()
    {
        p1 = GameObject.Find("FirstPersonCharacter").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, (float)60.0f * Time.deltaTime, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isGold)
            {
                p1.gotGold = true;
                this.gameObject.SetActive(false);
            }
            else if(isSilver)
            {
                p1.gotSilver = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
