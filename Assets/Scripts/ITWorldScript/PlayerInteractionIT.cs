using UnityEngine;
using System.Collections;

public class PlayerInteractionIT : MonoBehaviour
{
    public ITWorldManager itWorldManager;
    public SpawnPopUps spawnPopUps;
    public bool canSpawnPopUps = false;

    public void Update(){
            if(Input.GetKeyDown(KeyCode.E) && canSpawnPopUps){
                spawnPopUps.StartSpawning();
                itWorldManager.FixedWorker();
            }
    }
     public void Awake()
    {
        itWorldManager = GameObject.Find("ITWorldManager").GetComponent<ITWorldManager>();
        spawnPopUps = GameObject.Find("ITWorldManager").GetComponent<SpawnPopUps>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Worker"))
        {
           
           if(other.gameObject == itWorldManager.GetSelectedWorker())
           {
              canSpawnPopUps = true;
              
               
           }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Worker"))
        {
            canSpawnPopUps = false;
        }
    }
}
