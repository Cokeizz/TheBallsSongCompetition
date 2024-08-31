using UnityEngine;

public class MatchPositionWithPlayer : MonoBehaviour
{
    // The player whose position will be matched
    [SerializeField] private Transform player;

    // Custom Y position that can be set in the Inspector
    [SerializeField] private float customYPosition;

    void Update()
    {
        if (player != null)
        {
            // Set the position of this object to the player's X and Z position, with a custom Y position
            transform.position = new Vector3(player.position.x, player.position.y + customYPosition, player.position.z);
        }
    }
}
