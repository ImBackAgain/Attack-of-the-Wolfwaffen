using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public GameObject lift;
    public float speed = 0.5f;
    public float position = 0f; // the lift's current y position
    public float startPos = 0f; // where the lift is on the ground
    public float ENDPOS = 24.3f;
    bool on = false;
    AudioSource music;
    AudioSource boss;
    bool isPlaying = false;

    public AudioSource NowPlaying
    {
        get
        {
            return isPlaying ? boss : music;
        }
    }

	// Use this for initialization
	void Start ()
    {      
        startPos = transform.position.y;
        position = startPos;
        AudioSource[] musics = GetComponents<AudioSource>();
        music = musics[0];
        boss = musics[1];
        boss.volume = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (position < ENDPOS && on ) // moves upwards until reaches end position
        {
            position += speed;
            transform.position = new Vector3(transform.position.x, position, transform.position.z);
            
        }

       if (on)
        {
            fadeOut();
        }
            


    }

    void OnTriggerEnter(Collider col)
    {
        on = true;
    }

    void fadeOut()
    {
        music.volume -= 0.005f;

        if (music.volume <= 0.0f)
        {
            if (!isPlaying)
            {
                boss.Play();
                isPlaying = true;
            }
            boss.volume += 0.005f;
        }
    }

    
}
