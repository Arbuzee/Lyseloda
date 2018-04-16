using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuPanel;

    private bool menuOpen;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
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
        pauseMenuPanel.SetActive(true);

        menuOpen = true;
    }

    public void ClosePauseMenu()
    {
        pauseMenuPanel.SetActive(false);

        menuOpen = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
