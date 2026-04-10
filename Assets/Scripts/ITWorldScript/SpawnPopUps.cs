using UnityEngine;

public class SpawnPopUps : MonoBehaviour
{
    public GameObject[] popUpPrefab; // Array of pop-up prefabs
    public RectTransform lowerBounds; // Lower bounds for spawning (UI RectTransform)
    public RectTransform upperBounds; // Upper bounds for spawning (UI RectTransform)

    public RectTransform parentObject; // Parent object for the spawned pop-ups (UI RectTransform)
    public GameObject screenCanvas;
    private int popDestroyed;

    private int totalPopUpsSpawned;

    public ITWorldManager itWorldManager;

    private bool isSpawning = false;

    private bool hasSpawned = false;
    public void Awake()
    {
        itWorldManager = GameObject.Find("ITWorldManager").GetComponent<ITWorldManager>();
    }

    public void Update()
    {
        if(!isSpawning)
        {
            screenCanvas.SetActive(false);
            // if(!hasSpawned){
            //     itWorldManager.FixedWorker();
            //     hasSpawned = true;
            // }
        }
        if(totalPopUpsSpawned >= 5)
        {
            CancelInvoke("SpawnPopUp");
        }
        if(popDestroyed == 5){
            isSpawning = false;
           
        }

        
    }
    public void SpawnPopUp()
    {
        // Calculate the left, right, top, and bottom bounds of the RectTransforms
        float lowerLeft = lowerBounds.anchoredPosition.x - (lowerBounds.rect.width * lowerBounds.pivot.x);
        float lowerRight = lowerBounds.anchoredPosition.x + (lowerBounds.rect.width * (1 - lowerBounds.pivot.x));
        float lowerBottom = lowerBounds.anchoredPosition.y - (lowerBounds.rect.height * lowerBounds.pivot.y);
        float upperTop = upperBounds.anchoredPosition.y + (upperBounds.rect.height * (1 - upperBounds.pivot.y));

        // Generate random position within bounds
        float x = Random.Range(lowerLeft, lowerRight); // Horizontal random position
        float y = Random.Range(lowerBottom, upperTop); // Vertical random position
        Vector2 spawnPosition = new Vector2(x, y);

        // Instantiate a random pop-up prefab
        int randomIndex = Random.Range(0, popUpPrefab.Length);
        GameObject popUp = Instantiate(popUpPrefab[randomIndex], parentObject);
        totalPopUpsSpawned++;
        // Set the position of the spawned pop-up relative to the parent
        RectTransform popUpRect = popUp.GetComponent<RectTransform>();
        if (popUpRect != null)
        {
            popUpRect.anchoredPosition = spawnPosition; // Set the position in local space
            popUpRect.localScale = Vector3.one; // Ensure the scale is correct
        }
        else
        {
            Debug.LogError("The spawned pop-up does not have a RectTransform!");
        }

    }

    public void PopDestroyed()
    {
        Debug.Log("Pop-up destroyed! Total destroyed: " + (popDestroyed + 1));
        popDestroyed++;
    }


    public void StartSpawning()
    {
        isSpawning = true;
        totalPopUpsSpawned = 0;
        popDestroyed = 0;
        screenCanvas.SetActive(true);
        InvokeRepeating("SpawnPopUp", 0f, 0.25f); 
    }
}