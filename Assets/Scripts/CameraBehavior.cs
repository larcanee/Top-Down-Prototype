using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target; // Reference to the object the camera should follow
    public float smoothSpeed = 0.125f; // Smoothing speed of the camera movement
    public Vector3 offset; // Offset of the camera from the target

    private bool isFollowing = false; // Flag to determine if the camera should follow the target

    void Update()
    {
        // Check if the "C" key is pressed to toggle camera following
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFollowing = !isFollowing;
        }
    }

    void LateUpdate()
    {
        // Check if the camera should follow the target
        if (isFollowing && target != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = target.position + offset;
            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the position of the camera
            transform.position = smoothedPosition;
        }
    }
}
