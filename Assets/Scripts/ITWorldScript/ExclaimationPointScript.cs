using UnityEngine;

public class ExclaimationPointScript : MonoBehaviour
{
    public float floatSpeed = 2f; // Speed of the up and down movement
    public float floatHeight = 0.5f; // Height of the up and down movement

    private Vector3 startPosition; // The starting position of the object

    void Start()
    {
        // Save the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the object's position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}