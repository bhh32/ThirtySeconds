/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour 
{
    [Header("Animation")]
    [SerializeField] Animator anim;

    [Header("Collider Settings")]
    [SerializeField] BoxCollider collider;
    Vector3 colliderStartSize;
    [SerializeField] float colliderReset;
    [SerializeField] float colliderResetStart = 0f;

    bool isJumping = false;

    [Header("Audio")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;
    [SerializeField] bool hasPlayed = false;
	
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
        if (Input.GetAxis("Jump") > 0f && !isJumping && !anim.GetBool("isJumping"))
        {
            if (!audio.isPlaying && !hasPlayed)
            {
                audio.PlayOneShot(clip);
                hasPlayed = !hasPlayed;
            }
            anim.SetBool("isJumping", true);
        }
        else
            anim.SetBool("isJumping", false);

        if (Input.GetAxis("Crouch") != 0f || Input.GetAxis("Controller Crouch") > .3f)
            anim.SetBool("isCrouching", true);
        else
            anim.SetBool("isCrouching", false);

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
        {
            Vector3 tempSize = new Vector3(collider.size.x, 1.5f, collider.size.z);
            collider.size = tempSize;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
        {
            collider.size = colliderStartSize;
            hasPlayed = false;
        }
    }
}
