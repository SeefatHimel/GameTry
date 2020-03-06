using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    bool gamePaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE...");
            if (gamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        PauseMenuUI.SetActive(false);
       // pausebtn.SetActive(true);

        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void pause()
    {
        PauseMenuUI.SetActive(true);
      //  pausebtn.SetActive(false);


        Debug.Log("Pause!");

        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void restartGame()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseMenuUI.SetActive(false);
   //     pausebtn.SetActive(true);

        Time.timeScale = 1f;
        gamePaused = false;

    }

    public void loadMainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        PauseMenuUI.SetActive(false);
    //    pausebtn.SetActive(true);

        Time.timeScale = 1f;
        gamePaused = false;

    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
