using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yo");
            other.gameObject.GetComponent<PlayerController>().ResetToCheckPoint();
            
        }
    }
}
