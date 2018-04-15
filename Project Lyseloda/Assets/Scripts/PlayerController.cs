using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject gameManager;
    private Rigidbody rgdbd;

    public float xSpeed = 1;
    public float jumpHeight = 5;

    private Vector3 pos;

    private float originalJumpHeight;

    void Start()
    {
        rgdbd = this.GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        originalJumpHeight = jumpHeight;
    }

    void Update () {
        float x = xSpeed * Input.GetAxis("Horizontal");
        pos = transform.position;
        rgdbd.MovePosition(pos + new Vector3(x, 0, 0));


        if(Input.GetKeyDown(KeyCode.Space))
        {
            rgdbd.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    }

    public void ResetJumpHeight()
    {
        jumpHeight = originalJumpHeight;
    }

    public void ResetToStartPoint()
    {
        rgdbd.MovePosition(gameManager.GetComponent<LevelManager>().startPoint);
    }

    public void ResetToCheckPoint()
    {
        transform.position = gameManager.GetComponent<LevelManager>().checkPoint;
    }

}
