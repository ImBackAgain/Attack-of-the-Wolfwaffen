using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobsDooorbelll : MonoBehaviour {

    BobButEvil bob;
	// Use this for initialization
	void Start () {
        bob = GameObject.Find("Bobject").GetComponent<BobButEvil>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bob.Awaken();
            Destroy(gameObject);
        }
    }
}
