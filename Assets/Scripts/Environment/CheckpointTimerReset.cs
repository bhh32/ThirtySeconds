using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTimerReset : MonoBehaviour
{
    [SerializeField] UITimer timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            timer.OnTimerUpdate();
    }
}
