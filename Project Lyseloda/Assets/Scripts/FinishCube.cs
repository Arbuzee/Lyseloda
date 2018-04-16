using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCube : MonoBehaviour {

    public int selectedLevel;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(selectedLevel, LoadSceneMode.Single);

        }

    }
}
