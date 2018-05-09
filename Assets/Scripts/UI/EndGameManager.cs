using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour 
{
    [SerializeField] UIHitpoints winLose;
    [SerializeField] GameObject endGameCanvas;
    [SerializeField] Text loseText;
    [SerializeField] Text winText;
	
	// Update is called once per frame
	void FixedUpdate () 
    {        
        if (winLose.lose)
        {
            endGameCanvas.SetActive(true);
            loseText.enabled = true;

            Time.timeScale = 0f;
        }
        else if (winLose.win)
        {
            endGameCanvas.SetActive(true);
            winText.enabled = true;

            Time.timeScale = 0f;
        }

	}
}
