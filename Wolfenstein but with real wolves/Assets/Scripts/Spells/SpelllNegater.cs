using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelllNegater : MonoBehaviour {
    GameObject sparklePref;
    public string targetTag;
    
    
    void Start()
    {
        sparklePref = Resources.Load<GameObject>("Sparkle!");
    }
    public void Nullify(SpellHitbox s)
    {
        if (s.targetTag == targetTag) return;

        Destroy(s.gameObject);

        GameObject nope = Instantiate(sparklePref);
        nope.transform.position = s.transform.position;
        nope.transform.rotation = s.transform.rotation;


        Destroy(nope, 1.5f);
    }
}
