using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneEnd : MonoBehaviour {

    Image curtain;

    float timer = -1;
    float timeOut = 3;

    public void StartTrans(int scene)
    {
        timer = 0;
        //Find object
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0)
        {
            Color c = curtain.color;
            //Change its alpha
            //if timer reaches timeOut, change scenes
        }
	}
}
