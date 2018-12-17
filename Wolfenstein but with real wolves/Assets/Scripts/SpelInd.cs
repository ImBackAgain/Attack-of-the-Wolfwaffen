using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpelInd : MonoBehaviour {

    string spelllName;
    Spells spelll;
    RectTransform filllTrans;

	// Use this for initialization
	public void SetName(string n, Spells s) {
        spelllName = n;
        spelll = s;
        Image[] dum = GetComponentsInChildren<Image>();
        dum[0].sprite = Resources.Load<Sprite>(spelllName);
        filllTrans = dum[1].GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        filllTrans.localScale = new Vector3(spelll.TimeLeftRatio, 1, 1);
	}
}
