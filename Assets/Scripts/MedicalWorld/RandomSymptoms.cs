using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject newPanel_fever;
    public GameObject newPanel_dizziness;
    public GameObject newPanel_musclepain;
    public GameObject newPanel_cough;

    public Animator npcAnimator;

    public GameObject npcGoalPosition;
    
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
       
        newPanel_fever = newPanel.transform.Find("Fever").gameObject;
        
        newPanel_dizziness = newPanel.transform.Find("Dizziness").gameObject;
        
        newPanel_musclepain = newPanel.transform.Find("Muscle Pain").gameObject;

        newPanel_cough = newPanel.transform.Find("Cough").gameObject;

        newNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI_fever = newPanel_fever;
        newNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI_dizziness = newPanel_dizziness;
        newNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI_musclepain = newPanel_musclepain;
        newNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI_cough = newPanel_cough;
        
        npcAnimator = newNPC.GetComponent<Animator>();
        StartCoroutine(MoveNPC(newNPC, npcGoalPosition.transform));
        }

    }
      private IEnumerator MoveNPC(GameObject npc, Transform target)
{
    Vector3 targetPosition = target.position;
    targetPosition.z = npc.transform.position.z;

    while (Vector2.Distance(npc.transform.position, targetPosition) > 0.1f)
    {
        npcAnimator.SetBool("isMoving", true);

        // Optional: auto-set direction
        Vector2 dir = (targetPosition - npc.transform.position).normalized;
        npcAnimator.SetFloat("Horizontal", -1);

        npc.transform.position = Vector2.MoveTowards(
            npc.transform.position,
            targetPosition,
            Time.deltaTime * 3f
        );

        yield return null;
    }

    npcAnimator.SetBool("isMoving", false);
    Debug.Log("NPC reached target GameObject!");
}
    
}
