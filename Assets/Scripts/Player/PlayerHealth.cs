/** Written By Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float maxHealth { get; private set;}
    public float currentHealth { get; private set; }
    public int lives { get; private set; }

    [SerializeField] PlayerCheckpoint checkpoint;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;

	// Use this for initialization
	void Start () 
    {
        maxHealth = 1f;
        currentHealth = maxHealth;

        lives = 3;
	}

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
            Reset();
    }

    // Not Needed in this script, but must be implemented due to IDamageable
    public void GiveDamage(GameObject obj, float damage)
    {
    }

    void Reset()
    {
        lives--;

        // TODO: Update the UI to reflect player has died

        audio.PlayOneShot(clip);

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
