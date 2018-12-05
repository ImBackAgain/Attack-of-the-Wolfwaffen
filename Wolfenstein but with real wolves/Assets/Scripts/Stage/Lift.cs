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

	// Use this for initialization
	void Start ()
    {      
        startPos = transform.position.y;
        position = startPos;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (position < ENDPOS && on ) // moves upwards until reaches end position
        {
            position += speed;
            transform.position = new Vector3(transform.position.x, position, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        on = true;
    }

    
}
