using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIGameManager2 : MonoBehaviour
{
    bool gameIsOver = false;
    public float restartDelay = 1f;
    public GameObject GameOverUI;


    public void EndGame()
    {
        if (gameIsOver == false)
        {
            gameIsOver = true;

            GameOverUI.SetActive(true);
            Debug.Log("Game Over!");
        }
    }
    public void BacktoGame()
    {
        SceneManager.UnloadSceneAsync("Combat2");
    }


    // public void Restart()
    // {
    //     SceneManager.LoadScene("Combat",LoadSceneMode.Additive);

    // }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");


    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }




}
