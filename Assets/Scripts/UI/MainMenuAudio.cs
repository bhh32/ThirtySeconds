using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour 
{
    [SerializeField] AudioSource audio;

    void Awake()
    {
        audio.playOnAwake = true;
    }
}
