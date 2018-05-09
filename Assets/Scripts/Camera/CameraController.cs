﻿/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField] GameObject player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(player != null)
            transform.position = player.transform.position + offset;
	}
}
