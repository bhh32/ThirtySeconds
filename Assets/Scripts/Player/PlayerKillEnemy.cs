/** Written By Bryan Hyland **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillEnemy : MonoBehaviour
{
    [SerializeField] float damage;

    void OnCollisionEnter(Collision other)
    {  
        Ray ray = new Ray();
        RaycastHit hit;

        ray.direction = -transform.up;
        ray.origin = transform.position + transform.up;

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.CompareTag("Enemy"))
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
