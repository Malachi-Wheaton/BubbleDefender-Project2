using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int maxHealth = 10; 
    private int currentHealth;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverUI; 

    private void Start()
    {
        currentHealth = maxHealth;  
        gameOverUI.SetActive(false); 
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
    }

    
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); 
    }

    
    private void GameOver()
    {
        
        gameOverUI.SetActive(true);

        
        Time.timeScale = 0f; 
        Debug.Log("Game Over!"); 
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            TakeDamage(1); 
        }

        
        Debug.Log("Current Health: " + currentHealth);
    }
}

