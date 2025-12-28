using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{

     
    public bool InteractedWithNPC;
    public GameObject DescriptionMenu;
    public bool isDescriptionMenuActive;

    public NPCMedicalScript npcMedicalScript;

    
    void Update(){

        if (Input.GetKeyDown(KeyCode.E) && InteractedWithNPC)
        {
            if(!isDescriptionMenuActive){
                Debug.Log("E Pressed");
            DescriptionMenu.SetActive(true);
            isDescriptionMenuActive = true;
            }
            else{
                DescriptionMenu.SetActive(false);
                isDescriptionMenuActive = false;
            }
            // Trigger dialogue or interaction here
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {

         if (other.CompareTag("NPC"))
    {
        Debug.Log("Interacted with: " + other.name);

        // Access the parent GameObject to get the NPCMedicalScript
        GameObject npcParent = other.transform.parent != null ? other.transform.parent.gameObject : other.gameObject;

        npcMedicalScript = npcParent.GetComponent<NPCMedicalScript>();
        if (npcMedicalScript == null)
        {
            Debug.LogError("NPCMedicalScript component is missing on the NPC or its parent!");
            return;
        }

        if (npcMedicalScript.symptomDisplayUI == null)
        {
            Debug.LogError("symptomDisplayUI is not assigned in NPCMedicalScript!");
            return;
        }

        DescriptionMenu = npcMedicalScript.symptomDisplayUI;
        InteractedWithNPC = true;
    }
        // if (other.CompareTag("NPC"))
        // {
        //    Debug.Log("Interacted");
        //       npcMedicalScript = other.GetComponent<NPCMedicalScript>();
        //       DescriptionMenu = npcMedicalScript.symptomDisplayUI;
        //       InteractedWithNPC = true;
        // }
        if(other.CompareTag("Recipe")){
            Debug.Log("Interacted with Recipe");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
           Debug.Log("Stopped Interacting");
              InteractedWithNPC = false;
              DescriptionMenu.SetActive(false);
              isDescriptionMenuActive = false;
        }

    }
}
