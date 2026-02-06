using UnityEngine;
using System.Collections;

public class BellShake : MonoBehaviour
{
    public float shakeAmount = 0.05f;
    public float shakeDuration = 0.3f;
    public float shakeSpeed = 40f;

    private Vector3 originalPosition;
    private bool playerNearby;
    private bool isShaking;

    public GameManager gameManager;
    public RandomSymptoms randomSymptoms;
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !isShaking)
        {
            if(gameManager.GetNPCTreated() == 0){     
                randomSymptoms.CreateNPC();
                gameManager.GameStarted();
            }else if(gameManager.GetNPCTreated() < 3){
                randomSymptoms.CreateNPC();
                gameManager.isAvailableSet(true);
            }else{
                Debug.Log("Game Ended");
                gameManager.EndGame();
            }
            StartCoroutine(Shake());
        }

    }

    IEnumerator Shake()
    {
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offset = Mathf.Sin(elapsed * shakeSpeed) * shakeAmount;
            transform.localPosition = originalPosition + new Vector3(offset, 0f, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        isShaking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
