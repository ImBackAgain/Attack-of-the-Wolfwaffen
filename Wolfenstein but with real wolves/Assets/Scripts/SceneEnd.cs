using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneEnd : MonoBehaviour {

    Image curtain;

    float timer = -1;
    float timeOut = 3;

    int sceneNum;

    public void StartTrans(int scene)
    {
        timer = 0;
        curtain = GetComponent<Image>();
        sceneNum = scene;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0)
        {
            timer += Time.deltaTime;
            Color c = curtain.color;

            c.a = timer / timeOut;

            curtain.color = c;

            if (timer > timeOut + 0.5f)
            {
                SceneManager.LoadScene(sceneNum);
            }
        }
	}
}
