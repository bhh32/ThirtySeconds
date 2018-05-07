/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour 
{
    [SerializeField] Rigidbody rb; // For jumping
    [SerializeField] float speed = 10f; // Running speed
    [SerializeField] float jumpHeight = 5f; // How high the character can jump
    [SerializeField] float jumpCooldown = .1f; // Time between jumps
    [SerializeField] float startJumpCooldown; // Container for the starting cooldown jump time

    Quaternion startFacingRight; // Container to keep the starting rotation

    void Start()
    {        
        startFacingRight = transform.rotation;
        startJumpCooldown = jumpCooldown;
    }
	
	// Update is called once per frame
	void Update () 
    {
        Move();
	}

    void Move()
    {
        float moveRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        bool jump = Input.GetKey(KeyCode.Space);

        // Movement
        if (moveRight > 0f)
        {
            if (transform.rotation.y != .7f)
            {
                var rot = new Quaternion(0f, .7f, 0f, 0.7f);
                transform.rotation = rot;
            }

            transform.Translate(0, 0f, moveRight);
        }
        else if (moveRight < 0f)
        {
            if (transform.rotation.y != startFacingRight.y * -1f)
            {
                var rot = new Quaternion(0f, startFacingRight.y * -1f, 0f, startFacingRight.w);
                transform.rotation = rot;
            }

            transform.Translate(0f, 0f, -moveRight);
        }

        // Jumping
        if (jump && jumpCooldown <= 0f)
        {
            jumpCooldown = startJumpCooldown;

            rb.AddForce(0f, jumpHeight, 0f, ForceMode.Impulse);
        }
        else
            jumpCooldown -= Time.deltaTime;

    }
}
