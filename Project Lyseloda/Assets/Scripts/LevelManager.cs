using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Vector3 startPoint;
    public Vector3 checkPoint;

    private GameObject[] activatePlatforms;
    private GameObject player;

    private float platforms;
    private float ruinedPlatforms;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetStartPoint();
        ResetCheckPoint();

        activatePlatformsCounter();

    }


    public void PlatformActivated()
    {
        platforms--;

        if (platforms < 1)
        {
            Completed();

        }
    }

    public void PlatformRuined()
    {
        ruinedPlatforms++;
    }

    private void Completed()
    {
        Debug.Log("Congratulations");
        Debug.Log("You ruined " + ruinedPlatforms + " platforms");
    }

    private void SetStartPoint()
    {
        startPoint = player.transform.position;
    }

    private void SetCheckPoint()
    {
        checkPoint = player.transform.position;
    }

    private void ResetCheckPoint()
    {
        checkPoint = startPoint;
    }

    public void ResetPlatforms()
    {
        foreach (GameObject tmp in activatePlatforms)
        {
            if (tmp.GetComponent<Cube>() != null)
            {
                tmp.GetComponent<Cube>().activeCounterEnabled = true;
                tmp.GetComponent<Cube>().ResetToInactive();
            }
        }
        activatePlatformsCounter();
    }

    private void activatePlatformsCounter()
    {
        platforms = 0;
        if (GameObject.FindGameObjectsWithTag("Platform").Length > 0)
        {
            activatePlatforms = GameObject.FindGameObjectsWithTag("Platform");

            foreach (GameObject tmp in activatePlatforms)
            {
                if (tmp.GetComponent<Cube>() != null)
                {
                    if (tmp.GetComponent<Cube>().activeCounterEnabled)
                    {
                        platforms++;
                    }
                }
            }
        }
    }
}
