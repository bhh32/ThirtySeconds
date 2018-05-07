/* Written by Evan Knebel */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieStrafe : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LevelGeometry")
        {
            speed *= -1;
        }
    }

    void Update ()
    {
        Vector3 move = new Vector3(speed, 0, 0);
        rb.velocity = move;
	}
}
