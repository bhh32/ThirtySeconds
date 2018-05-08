using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour 
{
    public Vector3 currentCheckpoint { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = transform.position;
            other.enabled = false;
        }
    }
}
