using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject HealthBar;
    public GameObject coinbar;
    public GameObject cardgallerybar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        HealthBar.SetActive(true);
        coinbar.SetActive(true);
        cardgallerybar.SetActive(true);

        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        HealthBar.SetActive(false);
        coinbar.SetActive(false);
        cardgallerybar.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

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
