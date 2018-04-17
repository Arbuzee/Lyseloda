using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Vector3 startPoint;
    public Vector3 checkPoint;

    private GameObject[] activatePlatforms;
    private GameObject[] specialPlatforms;
    private GameObject player;

    private float platforms;
    private float ruinedPlatforms;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().ResetToStartPoint();
        //SetStartPoint();
        ResetCheckPoint();

        ActivatePlatformsCounter();
        GetSpecialPlatforms();
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
        foreach (GameObject tmp in specialPlatforms)
        {
            if (tmp.GetComponent<Cube>() != null)
            {
                tmp.GetComponent<Cube>().ResetToInactive();
            }

            if (tmp.GetComponent<BouncyCube>() != null)
            {
                tmp.GetComponent<BouncyCube>().ResetValues();
            }

            if (tmp.GetComponent<PortalCube>() != null)
            {
                tmp.GetComponent<PortalCube>().InstaResetToUsable();
            }
        }

        foreach (GameObject tmp in activatePlatforms)
        {
            if (tmp.GetComponent<Cube>() != null)
            {
                tmp.GetComponent<Cube>().activeCounterEnabled = true;
                tmp.GetComponent<Cube>().ResetToInactive();
            }
        }
        ActivatePlatformsCounter();
    }

    private void ActivatePlatformsCounter()
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

    private void GetSpecialPlatforms()
    {
        if (GameObject.FindGameObjectsWithTag("SpecialPlatform").Length > 0)
        {
            specialPlatforms = GameObject.FindGameObjectsWithTag("SpecialPlatform");
        }
    }
}
