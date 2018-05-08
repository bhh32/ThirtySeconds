/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] BoxCollider collider;
    Vector3 colliderStartSize;
    [SerializeField] float colliderReset;
    [SerializeField] float colliderResetStart = 0f;

    bool isJumping = false;
	
    void Start()
    {
        colliderStartSize = collider.size;
        colliderReset = colliderResetStart;
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
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
        {
            Vector3 tempSize = new Vector3(collider.size.x, 1.75f, collider.size.z);
            collider.size = tempSize;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
            collider.size = colliderStartSize;
    }
}
