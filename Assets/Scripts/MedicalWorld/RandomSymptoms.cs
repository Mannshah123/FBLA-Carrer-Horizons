using UnityEngine;

public class RandomSymptoms : MonoBehaviour
{
    public Symptons[] symptons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject NPC;
    public GameObject NPCSpawnPoint;
    public GameObject canvas;
    public GameObject newNPC;
    public GameObject panel;
    public GameObject newPanel;
    void Start()
    {
        
        
        // SymptomDisplayUI displayUI = symptomDisplay.GetComponent<SymptomDisplayUI>();
        // displayUI.UpdateSymptoms(selectedSymptom);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNPC(){
        if(newNPC == null){
             int randomIndex = Random.Range(0, symptons.Length);
        Symptons selectedSymptom = symptons[randomIndex];

        Debug.Log("Selected Symptom: " + selectedSymptom.name);
       
       newNPC =  Instantiate(NPC, NPCSpawnPoint.transform.position, Quaternion.identity);
        
         newPanel = Instantiate(panel);
        
        newPanel.transform.SetParent(canvas.transform, false);
        
        newNPC.GetComponent<NPCMedicalScript>().currentSymptoms = selectedSymptom;
        
        newNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI = newPanel;
       
        }
       
    }
}
