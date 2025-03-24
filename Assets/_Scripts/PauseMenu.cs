using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    public GameObject pauseMenuUI; 
    public Button resumeButton;    
    public Button quitButton;      

    private bool isPaused = false;  

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);

        
        pauseMenuUI.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed!"); // This will show in the Console when the Escape key is pressed
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }



    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;          
        pauseMenuUI.SetActive(true);  
    }

    
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;          
        pauseMenuUI.SetActive(false); 
    }

    
    void QuitGame()
    {
        
        Debug.Log("Quit the game");
        Application.Quit(); 
    }
}
