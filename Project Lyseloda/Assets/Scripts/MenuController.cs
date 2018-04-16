using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject buttons;
    public GameObject selectLevelPanel;


    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SelectLevel()
    {
        if (selectLevelPanel.activeSelf)
        {
            selectLevelPanel.SetActive(false);
            buttons.SetActive(true);
        } else
        {
            selectLevelPanel.SetActive(true);
            buttons.SetActive(false);
        }
        
    }

    public void StartLevel(int selectedLevel)
    {
        SceneManager.LoadScene(selectedLevel, LoadSceneMode.Single);
    }

}
