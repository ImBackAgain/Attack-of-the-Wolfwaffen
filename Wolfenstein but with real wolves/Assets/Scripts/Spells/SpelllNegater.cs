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

        GameObject noper = Instantiate(sparklePref);

        ParticleSystem.MainModule ps = noper.GetComponent<ParticleSystem>().main;

        noper.transform.position = s.transform.position;
        noper.transform.rotation = s.transform.rotation;
        
        if (s is FireCollision)
        {
            ps.startColor = new Color(1, 0.3f, 0);
        }
        if (s is LightningCollision)
        {
            ps.startColor = new Color(0.7f, 1, 0.5f);
        }
        if (s is IceCollision)
        {
            ps.startColor = new Color(0, 0.3f, 1);
        }

        Destroy(noper, 1.5f);
    }
}
