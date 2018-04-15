using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Vector3 startPoint;
    public Vector3 checkPoint;

    private GameObject player;

    private float platforms;
    private float ruinedPlatforms;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (GameObject.FindGameObjectsWithTag("Platform").Length > 0)
        {
            platforms = GameObject.FindGameObjectsWithTag("Platform").Length;
        }

        SetStartPoint();
        ResetCheckPoint();
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
}
