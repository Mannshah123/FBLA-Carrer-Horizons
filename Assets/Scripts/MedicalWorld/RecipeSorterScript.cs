using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class RecipeSorterScript : MonoBehaviour
{

    public GameObject syringeRecipePanel;
    public GameObject medicineRecipePanel;


    public GameObject descriptionPrefab;
    public Symptons[] syringeSymptoms;
    public Symptons[] medicineSymptoms;

    private int totalSymptoms = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i =0; i< syringeSymptoms.Length; i++){
            GameObject descriptionInstance = Instantiate(descriptionPrefab);
            descriptionInstance.transform.SetParent(syringeRecipePanel.transform, false);
            descriptionInstance.GetComponentInChildren<TMP_Text>().text = syringeSymptoms[i].name;
            Transform textTransform = descriptionInstance.transform.Find("Description");

            if (syringeSymptoms[i].fever)
        {
            textTransform.GetComponent<TMP_Text>().text += "Fever";
            totalSymptoms++;
        }

        if (syringeSymptoms[i].dizziness)
        {
            if (totalSymptoms > 0)
            {
                textTransform.GetComponent<TMP_Text>().text += "     &     ";
            }

            textTransform.GetComponent<TMP_Text>().text += "Dizziness";
            totalSymptoms++;
        }

        if (syringeSymptoms[i].MusclePain)
        {
            if (totalSymptoms > 1)
            {
                textTransform.GetComponent<TMP_Text>().text += "\nMuscle Pain";
            }
            else if (totalSymptoms > 0)
            {
                textTransform.GetComponent<TMP_Text>().text += "     &     ";
                textTransform.GetComponent<TMP_Text>().text += "Muscle Pain";
            }
            else
            {
                textTransform.GetComponent<TMP_Text>().text += "Muscle Pain";
            }
            totalSymptoms++;
        }

        if (syringeSymptoms[i].cough)
        {
            if (totalSymptoms > 2)
            {
                textTransform.GetComponent<TMP_Text>().text += "     &     ";
                textTransform.GetComponent<TMP_Text>().text += "Cough";
            }
            else if (totalSymptoms > 1)
            {
                textTransform.GetComponent<TMP_Text>().text += "\nCough";
            }
            else if (totalSymptoms > 0)
            {
                textTransform.GetComponent<TMP_Text>().text += "     &     ";
                textTransform.GetComponent<TMP_Text>().text += "Cough";
            }
            else
            {
                textTransform.GetComponent<TMP_Text>().text += "Cough\n";
            }
            totalSymptoms++;
        }

        // Reset totalSymptoms for the next symptom
        totalSymptoms = 0;
        }

        for(int j =0; j< medicineSymptoms.Length; j++){
            GameObject descriptionInstance = Instantiate(descriptionPrefab);
            descriptionInstance.transform.SetParent(medicineRecipePanel.transform, false);
            descriptionInstance.GetComponentInChildren<TMP_Text>().text = medicineSymptoms[j].name;
            Transform textTransform = descriptionInstance.transform.Find("Description");
            if(medicineSymptoms[j].fever){
                textTransform.GetComponent<TMP_Text>().text += "Fever";
                totalSymptoms++;
            }

            if(medicineSymptoms[j].dizziness){
                if(totalSymptoms > 0 ){
                    textTransform.GetComponent<TMP_Text>().text += "     &     ";
                }

                textTransform.GetComponent<TMP_Text>().text += "Dizziness";
                totalSymptoms++;
                
            }

            if(medicineSymptoms[j].MusclePain){
                if(totalSymptoms > 1 ){
                    textTransform.GetComponent<TMP_Text>().text += "\nMuscle Pain";
                        totalSymptoms++;
                }else if(totalSymptoms > 0){
                        textTransform.GetComponent<TMP_Text>().text += "     &     ";
                    textTransform.GetComponent<TMP_Text>().text += "Muscle Pain";
                    totalSymptoms++;
                }else{
                    textTransform.GetComponent<TMP_Text>().text += "Muscle Pain";
                    totalSymptoms++;
                }
               
            }
            if(medicineSymptoms[j].cough){
                if(totalSymptoms > 2){
                     textTransform.GetComponent<TMP_Text>().text += "     &     ";
                     textTransform.GetComponent<TMP_Text>().text += "Cough";
                }else if(totalSymptoms >1){
                    textTransform.GetComponent<TMP_Text>().text += "\nCough";
                }else if(totalSymptoms >0){
                    textTransform.GetComponent<TMP_Text>().text += "     &     ";
                    textTransform.GetComponent<TMP_Text>().text += "Cough";
                }else{
                textTransform.GetComponent<TMP_Text>().text += "Cough\n";
                }
            }
            // TMP_Text descriptionText = descriptionInstance.GetComponent<TMP_Text>();
            // descriptionText.text = medicineSymptoms[j].symptomName + ": " + medicineSymptoms[j].treatmentDescription;
            totalSymptoms = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
