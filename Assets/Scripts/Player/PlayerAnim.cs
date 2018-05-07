/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] CapsuleCollider collider;
    float colliderStartSize;
    [SerializeField] float colliderReset = 5f;

    bool isJumping = false;
	
    void Start()
    {
        colliderStartSize = collider.height;
        Debug.Log(colliderStartSize);
    }

	// Update is called once per frame
	void Update ()
    {
        // Movement Animations
        if (Input.GetAxis("Horizontal") != 0f)
            anim.SetFloat("speed", 1f);
        else
            anim.SetFloat("speed", 0f);

        // Jumping Animations
        if (Input.GetKey(KeyCode.Space) && !isJumping && !anim.GetBool("isJumping"))
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);


        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Jumping"))
            collider.height = 1f;
        else
            collider.height = colliderStartSize;
    }
}
