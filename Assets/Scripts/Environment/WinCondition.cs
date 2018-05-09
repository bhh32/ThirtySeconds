using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour 
{
    [SerializeField] UIHitpoints updateUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerHealth>();
            player.win = true;
            player.OnEndGame();
        }
    }
}
