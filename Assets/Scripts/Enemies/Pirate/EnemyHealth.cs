using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable 
{
    [SerializeField] float health;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
            Destroy(gameObject);
    }

    public void GiveDamage(GameObject obj, float damage)
    {
        Ray ray = new Ray();

        var origin = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y / 2f, transform.position.z);

        ray.direction = transform.forward;
        ray.origin = origin;

        RaycastHit hit;
        Debug.DrawRay(ray.origin, obj.transform.position, Color.red);

        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Player"))
                hit.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else
            ray.direction = -transform.forward;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Player"))
                hit.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
