using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;


    public void PlayGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitGame()
    {
       Application.Quit();
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);
    }


}
