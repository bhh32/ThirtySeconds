using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndGameManager : MonoBehaviour 
{
    [SerializeField] UIHitpoints winLose;
    [SerializeField] GameObject endGameCanvas;
    [SerializeField] GameObject playAgainButton;
	
	// Update is called once per frame
	void FixedUpdate ()
    {        
        if (winLose.lose || winLose.win)
            endGameCanvas.SetActive(true);

        if (endGameCanvas.activeSelf)
        {
            if (EventSystem.current.firstSelectedGameObject != playAgainButton)
                EventSystem.current.firstSelectedGameObject = playAgainButton;
        
            Debug.Log(EventSystem.current.firstSelectedGameObject.name);
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
        }
    }
}
