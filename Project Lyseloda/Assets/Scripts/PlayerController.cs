using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject gameManager;
    private GameObject groundCheck;
    private Rigidbody rgdbd;

    public float xSpeed = 1;
    public float jumpHeight = 5;

    private Vector3 pos;

    private float originalJumpHeight;
    private bool isGrounded;

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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GroundCheck();
            if (isGrounded)
            {
                rgdbd.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
        }
    }

    private void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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
