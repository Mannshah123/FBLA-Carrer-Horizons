using UnityEngine;
using System.Collections;
public class ITWorldManager : MonoBehaviour
{
    public GameObject[] workers;

    private bool isWorkerSelected = false;

    int randWorker;
    
    public ExclaimationPointScript exclamationPointScript;
    public GameObject exclamationPointMain;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        //access special method from the workers after this point
        if(!isWorkerSelected){
            randWorker = Random.Range(0, workers.Length);
            SetExclamationPoint(workers[randWorker]);
            // workers[randWorker].GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Worker " + randWorker + " is selected.");
            // Instantiate(exclaimationPointPrefab, workers[randWorker].transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isWorkerSelected = true;
        }
       
    }

    public GameObject GetSelectedWorker(){
        return workers[randWorker];
    }

    public void FixedWorker(){
            workers[randWorker].GetComponent<SpriteRenderer>().color = Color.white;
            isWorkerSelected = false;
    }

    public void SetExclamationPoint(GameObject worker){
        exclamationPointMain.transform.SetParent(worker.transform);

        exclamationPointMain.transform.localPosition = new Vector3(0, 1, 0);
        // exclamationPointScript.SetStartPosition(exclamationPointMain.transform.position);
        exclamationPointMain.SetActive(true);

    }
}
