using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAudio : MonoBehaviour 
{
    [SerializeField] AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            audio.PlayOneShot(audio.clip);
    }
}
