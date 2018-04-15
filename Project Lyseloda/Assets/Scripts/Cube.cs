using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private GameObject gameManager;

    public Material active;
    public Material ruined;
    private Material normal;
    private Renderer mat;

    public bool lightable;

    private bool activated;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        mat = GetComponent<Renderer>();
        normal = mat.material;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (activated)
            {
                mat.material = ruined;
                if (lightable)
                {
                    gameManager.GetComponent<LevelManager>().PlatformRuined();
                }
                
            }
            else
            {
                //Contact point might be useful
                mat.material = active;
                if (lightable)
                {
                    gameManager.GetComponent<LevelManager>().PlatformActivated();
                }

            }
            
        }

    }

    private void OnCollisionExit(Collision other)
    {
        activated = true;
    }

    public void ResetToInactive()
    {
        mat.material = normal;
        activated = false;
    }
}
