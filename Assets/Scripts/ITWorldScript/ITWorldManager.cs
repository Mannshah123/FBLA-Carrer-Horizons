using UnityEngine;
using System.Collections;
public class ITWorldManager : MonoBehaviour
{
    public GameObject[] workers;

    private bool isWorkerSelected = false;

    public GameObject exclaimationPointPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randWorker = Random.Range(0, workers.Length);


        //access special method from the workers after this point
        if(!isWorkerSelected){
            workers[randWorker].GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(exclaimationPointPrefab, workers[randWorker].transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isWorkerSelected = true;
        }
       
    }
}
