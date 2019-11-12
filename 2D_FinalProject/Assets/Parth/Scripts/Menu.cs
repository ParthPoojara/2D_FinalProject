using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitGame()
    {
       Application.Quit();
        
    }


}
