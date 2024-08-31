using UnityEngine;

public class ScaleBasedOnMultipleYRanges : MonoBehaviour
{
    [System.Serializable]
    public struct YScaleRange
    {
        public float minYPosition; // Minimum Y position for the range
        public float maxYPosition; // Maximum Y position for the range
        public Vector3 scale; // Scale to apply within this range
    }

    // Serialized array to define multiple Y position ranges and their corresponding scales
    [SerializeField] private YScaleRange[] yScaleRanges;

    // Original scale to revert back to when outside all ranges
    [SerializeField] private Vector3 originalScale = new Vector3(1f, 1f, 1f);

    void Update()
    {
        // Get the current Y position of the object
        float yPos = transform.position.y;
        Debug.Log("Current Y Position: " + yPos);

        // Check each range to see if the Y position is within any of them
        bool isInRange = false;
        foreach (var range in yScaleRanges)
        {
            Debug.Log("Checking range: " + range.minYPosition + " to " + range.maxYPosition);
            if (yPos >= range.minYPosition && yPos <= range.maxYPosition)
            {
                // Set the scale to the corresponding scale for the range
                Debug.Log("Within range. Setting scale to: " + range.scale);
                transform.localScale = range.scale;
                isInRange = true;
                break;
            }
        }

        // If the Y position is not within any range, revert to the original scale
        if (!isInRange)
        {
            Debug.Log("Not in any range. Reverting to original scale: " + originalScale);
            transform.localScale = originalScale;
        }
    }
}
