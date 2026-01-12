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

    public GameObject RecipeMenu;
    public bool RecipeIteracted;

    public GameObject syringeRecipeMenu;
    public bool syringeRecipeInteracted;
    

    public GameObject mixedRecipeMenu;
    public bool mixedRecipeInteracted;
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

        if(Input.GetKeyDown(KeyCode.E) && RecipeIteracted){
            if(!RecipeMenu.activeSelf){
                Debug.Log("E Pressed on Recipe");
                RecipeMenu.SetActive(true);
            }
            else{
                RecipeMenu.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && syringeRecipeInteracted){
            if(!syringeRecipeMenu.activeSelf){
                Debug.Log("E Pressed on Syringe Recipe");
                syringeRecipeMenu.SetActive(true);
            }
            else{
                syringeRecipeMenu.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && mixedRecipeInteracted){
            if(!mixedRecipeMenu.activeSelf){
                Debug.Log("E Pressed on Mixed Recipe");
                mixedRecipeMenu.SetActive(true);
            }
            else{
                mixedRecipeMenu.SetActive(false);
            }
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
            RecipeIteracted = true;
        }


        if(other.CompareTag("SyringeRecipe")){
            Debug.Log("Interacted with Syringe Recipe");
            syringeRecipeInteracted = true;
        }

        if(other.CompareTag("MixRecipe")){
            Debug.Log("Interacted with Mixed Recipe");
            mixedRecipeInteracted = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
          
              InteractedWithNPC = false;
              DescriptionMenu.SetActive(false);
              isDescriptionMenuActive = false;
        }

        if(other.CompareTag("Recipe")){
            
            RecipeIteracted = false;
            RecipeMenu.SetActive(false);
        }
        if(other.CompareTag("SyringeRecipe")){
            
            syringeRecipeInteracted = false;
            syringeRecipeMenu.SetActive(false);
        }
        if(other.CompareTag("MixRecipe")){
            
            mixedRecipeInteracted = false;
            mixedRecipeMenu.SetActive(false);
        }

    }
}
