using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject gameOverPanel; // Assign in the Inspector

    private bool isGameOver = false;

    public static GameOverManager instance; // Singleton instance

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f; // Freeze game
        gameOverPanel.SetActive(true); // Show Game Over panel
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Reset time scale before quitting
        Application.Quit();
    }
}

