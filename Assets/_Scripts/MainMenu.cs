using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene"); 
    }

    public void OpenInstructions()
    {
        SceneManager.LoadScene("InstructionsScene"); 
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Quit Game"); 
    }
}

