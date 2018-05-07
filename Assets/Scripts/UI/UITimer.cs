/** Written by Evan Knebel **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITimer : MonoBehaviour
{
    public Text timerDisplay;

    public float timer = 30.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        timerDisplay.text = timer.ToString();
        if (timer <= 0)
        {
            SceneManager.LoadScene("EvanDevScene");
        }

    }
}
