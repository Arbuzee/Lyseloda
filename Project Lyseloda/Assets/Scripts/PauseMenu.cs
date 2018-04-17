using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;

    private bool menuOpen;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuOpen)
                {
                    ClosePauseMenu();
                }
                else
                {
                    OpenPauseMenu();
                }

            }
        }

    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        
        menuOpen = true;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);

        menuOpen = false;
    }

    public void BackToMenu()
    {
        ClosePauseMenu();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
