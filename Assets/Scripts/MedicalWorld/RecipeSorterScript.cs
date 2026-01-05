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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i =0; i< syringeSymptoms.Length; i++){
            GameObject descriptionInstance = Instantiate(descriptionPrefab);
            descriptionInstance.transform.SetParent(syringeRecipePanel.transform, false);
            descriptionInstance.GetComponentInChildren<TMP_Text>().text = syringeSymptoms[i].name;
        }

        for(int j =0; j< medicineSymptoms.Length; j++){
            GameObject descriptionInstance = Instantiate(descriptionPrefab);
            descriptionInstance.transform.SetParent(medicineRecipePanel.transform, false);
            descriptionInstance.GetComponentInChildren<TMP_Text>().text = medicineSymptoms[j].name;
            // TMP_Text descriptionText = descriptionInstance.GetComponent<TMP_Text>();
            // descriptionText.text = medicineSymptoms[j].symptomName + ": " + medicineSymptoms[j].treatmentDescription;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
