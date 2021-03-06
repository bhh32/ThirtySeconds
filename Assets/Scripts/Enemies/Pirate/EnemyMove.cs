﻿/** Written By Bryan Hyland **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
    [SerializeField] float speed;
    Quaternion startRotation;

    [SerializeField] float damage;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TurnTrigger") || other.gameObject.CompareTag("Enemy"))
        {
            if (transform.rotation.y == startRotation.y)
            {
                var rotateLeft = new Quaternion(0f, startRotation.y * -1, 0f, startRotation.w);
                transform.rotation = rotateLeft;
            }
            else
                transform.rotation = startRotation;
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.collider.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
