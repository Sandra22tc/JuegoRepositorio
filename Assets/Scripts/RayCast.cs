using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float jumpForce = 10f;
    public float raycastDistance = 0.1f;
    public Transform groundCheck;
    private bool isJumping;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Perform a raycast from the groundCheck position in the downward direction
        if (Physics.Raycast(groundCheck.position, -Vector3.up, raycastDistance))
        {
            // If the raycast hit something, the player is on the ground
            isJumping = false;
        }
        else
        {
            // If the raycast did not hit anything, the player is in the air
            isJumping = true;
        }

        // Jump if the player is on the ground and the jump button is pressed
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

