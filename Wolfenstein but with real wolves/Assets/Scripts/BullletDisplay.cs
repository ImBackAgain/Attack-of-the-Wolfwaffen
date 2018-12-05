using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletDisplay : MonoBehaviour {

    Player player;

    GameObject bullletIconPrefab;
    int bullletSeparation;
    int bullletCount;
    List<GameObject> bulletIcons;

    void ResetBulletCount()
    {
        if (bullletCount < bulletIcons.Count)
        {
            //Debug.Log("NewCount is " + bullletCount);
            for(int i = bulletIcons.Count; i > bullletCount; i--)
            {
                Destroy(bulletIcons[i - 1]);
                bulletIcons.RemoveAt(i - 1);
            }
        }
        else if (bullletCount > bulletIcons.Count)
        {
            for (int i = bulletIcons.Count; i < bullletCount; i++)
            {
                bulletIcons.Add(Instantiate(bullletIconPrefab,
                    transform.position - i * bullletSeparation * Vector3.right, Quaternion.identity, transform));
            }
        }
    }

    // Use this for initialization
    void Start () {
        bulletIcons = new List<GameObject>();
        bullletIconPrefab = Resources.Load<GameObject>("BulletIcon");
        bullletSeparation = (int)bullletIconPrefab.GetComponent<RectTransform>().rect.width + 3;
        bullletCount = 0;

        player = GameObject.Find("FPSController").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bullletCount != player.AmmoLeft)
        {
            bullletCount = player.AmmoLeft;
            ResetBulletCount();
        }
	}
}
