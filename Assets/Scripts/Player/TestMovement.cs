using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    void Update()
    {
        if (!Input.anyKey)
        {
            Vector3 move = new Vector3(0, 0, 0);
            rb.velocity = move;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 move = new Vector3(0, speed, 0);
            rb.velocity = move;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 move = new Vector3(0, -speed, 0);
            rb.velocity = move;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 move = new Vector3(-speed, 0, 0);
            rb.velocity = move;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 move = new Vector3(speed, 0, 0);
            rb.velocity = move;
        }
    }
}
