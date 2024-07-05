using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private bool isOnGround = true;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        JumpAction();
    }

    private void JumpAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
