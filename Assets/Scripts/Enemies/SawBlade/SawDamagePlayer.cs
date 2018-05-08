using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamagePlayer : MonoBehaviour
{
    PlayerHealth playerhealth;

    private void Start()
    {
        playerhealth = GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerhealth.TakeDamage(1);
        }
    }
}
