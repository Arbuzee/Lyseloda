using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private GameObject gameManager;

    public Material active;
    public Material ruined;

    private Material normal;
    private Renderer mat;

    public bool activeCounterEnabled;
    public bool canGetRuined;
    
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
                if (canGetRuined)
                {
                    mat.material = ruined;
                    if (activeCounterEnabled)
                    {
                        gameManager.GetComponent<LevelManager>().PlatformRuined();
                    }

                }
                
            }
            else
            {
                activated = true;
                mat.material = active;
                if (activeCounterEnabled)
                {
                    gameManager.GetComponent<LevelManager>().PlatformActivated();
                }

            }
            
        }

    }

    public void ResetToInactive()
    {
        mat.material = normal;
        activated = false;
    }

    public void SetPortalInactiveColor()
    {
        mat.material = active;
    }
}
