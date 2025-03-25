using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; 

    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 100;  
    private int currentHealth;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;  

    [Header("Events")]
    public UnityEvent onPlayerDie;  

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;  

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned in PlayerHealth script!");
        }
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  
        Debug.Log($"Player (Base) took {damage} damage, current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();  
        }
    }

    
    private void Die()
    {
        Time.timeScale = 0f;  

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  
        }
        else
        {
            Debug.LogError("Game Over Panel is missing. Assign it in the Inspector.");
        }

        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;  
        onPlayerDie?.Invoke();  
    }

    
    public void RestartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    
    public void QuitGame()
    {
        Time.timeScale = 1f;  
        Application.Quit();  
    }
}





