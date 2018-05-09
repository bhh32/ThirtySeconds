using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndGameCanvas : MonoBehaviour 
{
    [SerializeField] UIHitpoints winLose;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject playAgainButton;

    void Awake()
    {
        if (winLose.lose)
            loseText.SetActive(true);
        else if (winLose.win)
            winText.SetActive(true);

        Time.timeScale = 0f;
    }
}
