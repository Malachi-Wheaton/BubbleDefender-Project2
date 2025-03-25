using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; // Static instance to reference PlayerHealth

    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 100;  // Max health of the player/base
    private int currentHealth;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;  // Reference to the Game Over Panel

    [Header("Events")]
    public UnityEvent onPlayerDie;  // Event to trigger when the player dies

    private void Awake()
    {
        // Ensure that only one instance of PlayerHealth exists
        if (instance == null)
        {
            instance = this; // Set this as the singleton instance
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy any duplicate PlayerHealth instances
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;  // Initialize the current health to max at the start

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  // Hide the Game Over Panel initially
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned in PlayerHealth script!");
        }
    }

    // Method to apply damage to the player (or base)
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Decrease health based on the damage
        Debug.Log($"Player (Base) took {damage} damage, current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();  // Call the Die method if health reaches 0 or less
        }
    }

    // This method is called when the player (base) dies
    private void Die()
    {
        Time.timeScale = 0f;  // Pause the game

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Show the Game Over Panel
        }
        else
        {
            Debug.LogError("Game Over Panel is missing. Assign it in the Inspector.");
        }

        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible
        onPlayerDie?.Invoke();  // Trigger the event for any listeners
    }

    // Restart the game when the player chooses to restart
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }

    // Quit the game
    public void QuitGame()
    {
        Time.timeScale = 1f;  // Reset the time scale
        Application.Quit();  // Quit the game
    }
}





