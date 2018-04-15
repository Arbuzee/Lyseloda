using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCube : MonoBehaviour {

    private GameObject player;

    public float stickyMultiplier;
    public float debuffTime = 2.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().jumpHeight *= stickyMultiplier;

            player = other.gameObject;
        }

        StartCoroutine(ResetDebuff());

    }

    IEnumerator ResetDebuff()
    {
        yield return new WaitForSeconds(debuffTime);
        player.GetComponent<PlayerController>().ResetJumpHeight();
    }
}