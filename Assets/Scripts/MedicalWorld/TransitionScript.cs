using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class TransitionScript : MonoBehaviour
{
  public Transform playerSpawn;
    public Transform cameraAnchor;
    public ScreenFader fader;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Transition(other.transform));
        }
    }

    IEnumerator Transition(Transform player)
    {
        // Optional: disable player movement here
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return fader.FadeOut();

        // Move player
        player.position = playerSpawn.position;

        // Move camera (keep Z unchanged)
        mainCam.transform.position = new Vector3(
            cameraAnchor.position.x,
            cameraAnchor.position.y,
            mainCam.transform.position.z
        );

        yield return fader.FadeIn();

        // Optional: re-enable player movement here
        player.GetComponent<PlayerMovement>().enabled = true;

    }
}
