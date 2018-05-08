using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour 
{
    [SerializeField] float firePower;
    [SerializeField] AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var rb = other.GetComponent<Rigidbody>();

            if (firePower > 0)
                rb.AddForce(firePower * Time.deltaTime, firePower * Time.deltaTime, 0f, ForceMode.Impulse);
            else if (firePower < 0)
                rb.AddForce(firePower * Time.deltaTime, (firePower * -1f) * Time.deltaTime, 0f, ForceMode.Impulse);

            audio.PlayOneShot(audio.clip);
        }
    }
}
