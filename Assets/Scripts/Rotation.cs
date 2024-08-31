using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    // Rotation speed in degrees per second
    [SerializeField] private float rotationSpeed = 100f;

    // Toggle rotation direction: true for forward (clockwise), false for backward (counterclockwise)
    [SerializeField] private bool rotateForward = true;

    void Update()
    {
        // Determine the rotation direction
        float direction = rotateForward ? -1 : 1;

        // Rotate the sprite around its Z-axis
        transform.Rotate(Vector3.forward * direction * rotationSpeed * Time.deltaTime);
    }
}
