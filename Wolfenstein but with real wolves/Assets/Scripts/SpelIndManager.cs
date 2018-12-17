using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelIndManager : MonoBehaviour {

    int vSpacing = 70;
    [SerializeField]
    GameObject spelIndPrefab;

    [SerializeField]
    SpelInd[] indicators;
    Dictionary<string, Spells> spellls;

	// Use this for initialization
	void Start () {
        spelIndPrefab = Resources.Load<GameObject>("Indicator");
        spellls = GameObject.Find("FPSController").GetComponent<Player>().spells;

        indicators = new SpelInd[spellls.Count];
        for (int i = 0; i < spellls.Count; i++)
        {
            GameObject ind = Instantiate(
                spelIndPrefab, 
                transform.position + i * vSpacing * Vector3.down, 
                Quaternion.identity, 
                transform
            );

            indicators[i] = ind.GetComponent<SpelInd>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
