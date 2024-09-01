using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startingPoint; // The position where the player will be reset
    public float maxIdleTime = 2.0f; // Maximum time the player can stay still
    public float pushUpForce = 5.0f; // Force to push the player up

    private Vector3 lastPosition;
    private float idleTimer;

    void Start()
    {
        // Manually set the startingPoint in the Unity Inspector or via code
        lastPosition = transform.position;
        idleTimer = 0f;
    }

    void Update()
    {
        CheckIfPlayerIsIdle();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "obstacle"
        if (collision.gameObject.CompareTag("obstacle"))
        {
            // Reset the player's position to the starting point
            transform.position = startingPoint;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            transform.position = startingPoint;
        }
    }

    void CheckIfPlayerIsIdle()
    {
        // If the player hasn't moved, increment the idle timer
        if (transform.position == lastPosition)
        {
            idleTimer += Time.deltaTime;
        }
        else
        {
            // If the player moved, reset the idle timer
            idleTimer = 0f;
        }

        // If the player is idle for more than the maxIdleTime, push the player up
        if (idleTimer >= maxIdleTime)
        {
            PushPlayerUp();
            idleTimer = 0f; // Reset the timer after pushing the player up
        }

        // Update the last position
        lastPosition = transform.position;
    }

    void PushPlayerUp()
    {
        // Push the player up by adding to the y-position
        transform.position += new Vector3(0f, pushUpForce, 0f);
    }
}
