using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStartMenu()
    {

        SceneManager.LoadScene(0);
    }
    public void LoadLevel()
    {

        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadGameOver()
    {
        
        SceneManager.LoadScene("Game Over");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
