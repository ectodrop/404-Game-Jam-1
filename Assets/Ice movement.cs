using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMovement : MonoBehaviour
{
    public float moveForce = 10.0f; // Force to apply for movement
    public float maxVelocity = 5.0f; // Maximum velocity for sliding effect

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true; // Freeze rotation on the X and Z axes
        }
    }

    void FixedUpdate() // Use FixedUpdate for Rigidbody operations
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the force direction
        Vector3 force = new Vector3(horizontalInput, 0f, verticalInput) * moveForce;

        // Apply the force to the Rigidbody
        rb.AddForce(force);

        // Clamp the velocity to simulate sliding effect without infinite acceleration
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        
    }
}

