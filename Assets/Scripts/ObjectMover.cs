using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Movement speed
    public float moveRange = 3.0f; // Range of movement

    private Vector3 startPosition;
    private bool moveRight = true;
    private bool moveForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
    }

    void MoveHorizontal()
    {
        float horizontalMove = Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(startPosition.x + horizontalMove, transform.position.y, transform.position.z);
    }

    void MoveVertical()
    {
        float verticalMove = Mathf.PingPong(Time.time * moveSpeed, moveRange * 2) - moveRange;
        transform.position = new Vector3(transform.position.x, transform.position.y, startPosition.z + verticalMove);
    }
}
