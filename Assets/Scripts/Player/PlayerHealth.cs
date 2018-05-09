/** Written By Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public delegate void EnableEndGame();
    public EnableEndGame OnEndGame;

    public float maxHealth { get; private set;}
    public float currentHealth { get; private set; }
    public int lives { get; set; }

    public bool win = false;
    public bool lose = false;

    [Header("Current Checkpoint")]
    [SerializeField] PlayerCheckpoint checkpoint;

    [Header("Audio")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;

    [Header("Update UI")]
    [SerializeField] UIHitpoints updateUI;
    [SerializeField] GameObject endGameCanvas;

	// Use this for initialization
	void Start () 
    {
        OnEndGame += EndGame;
        maxHealth = 1f;
        currentHealth = maxHealth;

        lives = 3;
	}

    void Update()
    {
        if (lives <= 0)
        {
            EndGame();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            if (gameObject.activeSelf)
                Reset();
            else
                EndGame();
        }
    }

    // Not Needed in this script, but must be implemented due to IDamageable
    public void GiveDamage(GameObject obj, float damage)
    {
    }

    void Reset()
    {
        lives--;

        updateUI.OnHitTaken();

        audio.PlayOneShot(clip);

        transform.position = checkpoint.currentCheckpoint;
    }

    void EndGame()
    {
        if (lives <= 0f)
            updateUI.lose = true;
        else
            updateUI.win = true;
        
        OnEndGame -= EndGame;

        gameObject.SetActive(false);
    }
}
