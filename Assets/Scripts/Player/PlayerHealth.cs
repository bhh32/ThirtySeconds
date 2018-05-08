using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float maxHealth { get; private set;}
    public float currentHealth { get; private set; }
    public int lives { get; private set; }

    [SerializeField] PlayerCheckpoint checkpoint;

	// Use this for initialization
	void Start () 
    {
        maxHealth = 1f;
        currentHealth = maxHealth;

        lives = 3;
	}

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage Taken!");
        currentHealth -= damage;

        if (currentHealth <= 0f)
            Reset();
    }

    public void GiveDamage(GameObject obj, float damage)
    {
    }

    void Reset()
    {
        lives--;

        // TODO: Update the UI to reflect player has died

        if (lives <= 0)
            EndGame();

        transform.position = checkpoint.currentCheckpoint;
    }

    void EndGame()
    {
        // TODO: Make a play again UI Screen
        Destroy(gameObject);
    }
}
