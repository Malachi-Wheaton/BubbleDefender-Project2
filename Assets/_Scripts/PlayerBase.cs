using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [Header("Base Health")]
    [SerializeField] private int baseHealth = 10; 
    private PlayerHealth playerHealth; 

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) 
        {
            
            playerHealth.TakeDamage(1); 

            
            Destroy(other.gameObject);

            
            baseHealth -= 1;
            if (baseHealth <= 0)
            {
                BaseDestroyed(); 
            }
        }
    }

    private void BaseDestroyed()
    {
        
        Debug.Log("Base destroyed!");
        
        Time.timeScale = 0f; 
    }
}

