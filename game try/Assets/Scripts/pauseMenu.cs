using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    bool gamePaused = false;

    public GameObject PauseMenuUI;
    public GameObject deathMenuUI;
    public Animator animator;

    public GameObject player;
    bool dead = false;

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

        int hp = player.GetComponent<Player_health>().playerHP();
        if (hp <= 0 && !dead)
            playerDead();
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
        deathMenuUI.SetActive(false);
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

    public void playerDead()
    {

        dead = true;
        deathMenuUI.SetActive(true);
        Debug.Log("deeeeeeeeeeaaaaaaaaaaaaad");
        animator.SetTrigger("start");
        Debug.Log("trrriiigggerrr");

        Time.timeScale = 0f;
        gamePaused = true;

    }
}
