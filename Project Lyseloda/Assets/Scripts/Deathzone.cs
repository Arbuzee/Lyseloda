using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GetComponent<LevelManager>().ResetPlatforms();

            other.gameObject.GetComponent<PlayerController>().ResetToCheckPoint();
            
        }
    }
}
