using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1f);
        }
    }
}
