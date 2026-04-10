using UnityEngine;
using UnityEngine.UI;

public class DeleteSelfScript : MonoBehaviour
{
    public SpawnPopUps spawnPopUps;
    
    public void Awake()
    {
        spawnPopUps = GameObject.Find("ITWorldManager").GetComponent<SpawnPopUps>();
    }
    public void DeleteSelf(GameObject button)
    {
        // Get the parent of the button
        Transform parentTransform = button.transform.parent;

        if (parentTransform != null)
        {
            // Destroy the parent GameObject
            Destroy(parentTransform.gameObject);
            spawnPopUps.PopDestroyed();
        }
        else
        {
            Debug.LogError("The button has no parent to destroy!");
        }
    }
}
