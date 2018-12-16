using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour {

    Player player;
    RectTransform barTransform;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("FPSController").GetComponent<Player>();
        barTransform = GameObject.Find("PlayerBar").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 scalable = barTransform.localScale;
        scalable.x = player.HealthRatio;
        barTransform.localScale = scalable;
	}
}
