using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCube : MonoBehaviour {


    public float bounceHeight;
    public float bounceHeightMultiplier = 0.5f;

    public int ruinedAfterUses = 1;

    private bool ruined;
    private float startBounceHeight;

    private void Start()
    {
        startBounceHeight = bounceHeight;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, bounceHeight, 0));

            if (ruinedAfterUses < 1)
            {
                ruined = true;
            }
            else
            {
                ruinedAfterUses--;
            }

            if (ruined)
            {
                if (bounceHeight >= startBounceHeight)
                {
                    bounceHeight *= bounceHeightMultiplier;
                }
                
            }

        }

    }

}
