using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCube : MonoBehaviour {

    public float bounceHeight;
    public float bounceHeightMultiplier = 0.5f;

    public int ruinedAfterUses = 1;
    private int startRuinedAfterUses;

    private float resetJumpHeightAfter = .25f;

    private bool ruined;
    private float startBounceHeight;

    private void Start()
    {
        startBounceHeight = bounceHeight;
        startRuinedAfterUses = ruinedAfterUses;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, bounceHeight, 0));
            other.gameObject.GetComponent<PlayerController>().jumpHeight = 0;
            StartCoroutine(ResetJumpHeight(other.gameObject));

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

    public void ResetValues()
    {
        bounceHeight = startBounceHeight;
        ruinedAfterUses = startRuinedAfterUses;
    }

    IEnumerator ResetJumpHeight(GameObject player)
    {
        yield return new WaitForSeconds(resetJumpHeightAfter);
        player.GetComponent<PlayerController>().ResetJumpHeight();
    }

}
