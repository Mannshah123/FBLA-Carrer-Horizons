using UnityEngine;

public class ExclaimationPointScript : MonoBehaviour
{
    public float floatSpeed = 2f; // Speed of the up and down movement
    public float floatHeight = 0.0001f; // Height of the up and down movement

    private Vector3 startPosition; // The starting position of the object
    private float newY; // The new Y position calculated in Update
    void Start()
    {
        // Save the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        //  newY = transform.position.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // // Update the object's position
        // transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position;
    }
}