/** Written by Evan Knebel **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITimer : MonoBehaviour
{
    public delegate void UpdateTimer();
    public UpdateTimer OnTimerUpdate;

    public Text timerDisplay;
    [SerializeField] UIHitpoints updateUI;

    public float timer = 31.0f;

	// Use this for initialization
	void Start ()
    {
        OnTimerUpdate += ResetTimer;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        int timerTrunc = (int)timer;
        timerDisplay.text = string.Format("Time Left: {0}", timerTrunc.ToString());
        if (timer <= 0f)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player.activeSelf)
            {
                updateUI.OnHitTaken();
                OnTimerUpdate();
            }
        }

    }

    void ResetTimer()
    {
        timer = 31f;
    }
}
