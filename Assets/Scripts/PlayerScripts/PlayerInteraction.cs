using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{

     
    public bool InteractedWithNPC;

    public GameObject interactedNPC;
    public GameObject DescriptionMenu; //access from the npc script
    public bool isDescriptionMenuActive;
    void Update(){

        if (Input.GetKeyDown(KeyCode.E) && InteractedWithNPC)
        {
            if(!isDescriptionMenuActive){
                Debug.Log("E Pressed");
                DescriptionMenu = interactedNPC.GetComponent<NPCMedicalScript>().symptomDisplayUI;
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
            interactedNPC = other.gameObject;
           Debug.Log("Interacted");
              InteractedWithNPC = true;
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
