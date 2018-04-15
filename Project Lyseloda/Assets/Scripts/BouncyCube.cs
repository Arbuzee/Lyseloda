using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCube : MonoBehaviour {


    public float bounceHeight;
    public float bounceHeightMultiplier = 0.5f;

    private bool activated;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, bounceHeight, 0));

            if (!activated)
            {
                bounceHeight *= bounceHeightMultiplier;

            }

        }

    }

    private void OnCollisionExit(Collision other)
    {
        activated = true;
    }
}
