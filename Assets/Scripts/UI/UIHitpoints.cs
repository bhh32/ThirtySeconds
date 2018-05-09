using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHitpoints : MonoBehaviour
{
    public delegate void HitTaken();
    public HitTaken OnHitTaken;

    int hitpoints = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    [SerializeField] PlayerHealth playerHealth;

    public bool win { get; set; }

    public bool lose { get; set; }

    UITimer timeout;

	// Use this for initialization
	void Start ()
    {
        timeout = GetComponent<UITimer>();

        win = false;
        lose = false;

        OnHitTaken += TakeHit;
	}

    void TakeHit()
    {
        if (timeout.timer > 0f)
        {
            if (life1.activeSelf)
                life1.SetActive(false);
            else if (life2.activeSelf)
                life2.SetActive(false);
            else if (life3.activeSelf)
                life3.SetActive(false);
        }

        if (timeout.timer <= 0f)
        {
            if (life1.activeSelf)
                life1.SetActive(false);
            else if (life2.activeSelf)
                life2.SetActive(false);
            else if (life3.activeSelf)
                life3.SetActive(false);

            if(playerHealth.gameObject.activeSelf)
                playerHealth.lives--;
        }
    }
}
