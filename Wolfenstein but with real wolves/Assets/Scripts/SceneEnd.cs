using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneEnd : MonoBehaviour {

    Image curtain;

    [SerializeField]
    float timer = -1;
    float timeOut = 3;

    AudioSource jukeBox;

    [SerializeField]
    int sceneNum;

    public void StartTrans(int scene)
    {
        //Debug.Log("Transition started!");
        timer = 0;
        curtain = GetComponent<Image>();
        sceneNum = scene;
        jukeBox = GameObject.Find("planks_floor_177").GetComponent<Lift>().NowPlaying;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(timer > -1);
		if (timer > -1)
        {
            //Debug.Log("then...");
            timer += Time.deltaTime;
            Color c = curtain.color;

            c.a = timer / timeOut;

            jukeBox.volume = 1 - timer / timeOut;

            curtain.color = c;

            if (timer > timeOut + 0.5f)
            {
                SceneManager.LoadScene(sceneNum);
            }
        }
	}
}
