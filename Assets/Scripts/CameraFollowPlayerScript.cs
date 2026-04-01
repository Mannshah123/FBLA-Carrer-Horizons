using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset;   

    public float smoothSpeed = 0.125f;
    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
             Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
             Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
             transform.position = smoothedPosition;
        }
    }
}