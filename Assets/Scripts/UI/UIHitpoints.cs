using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHitpoints : MonoBehaviour
{
    int hitpoints = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    UITimer timeout;

    public bool debugDamage = false;

	// Use this for initialization
	void Start ()
    {
        timeout = GetComponent<UITimer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (debugDamage == true)
        {
            debugDamage = false;
            hitpoints -= 1;
        }

        if (timeout.timer <= 0)
        {
            hitpoints -= 1;
        }
        
        if (hitpoints == 2)
        {
            Destroy(life1.gameObject);
        }
        else if (hitpoints == 1)
        {
            Destroy(life2.gameObject);
        }
        else if (hitpoints == 0)
        {
            Destroy(life3.gameObject);
        }
    }
}
