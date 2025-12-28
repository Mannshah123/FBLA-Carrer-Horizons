using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class NPCMedicalScript : MonoBehaviour
{
    public Symptons currentSymptoms;

    public bool Fever;
    public bool Dizziness;
    public bool MusclePain;
    public bool Cough;

    public bool isTreated;



    public GameObject symptomDisplayUI;
    public GameObject symptomDisplayUI_fever;
    public GameObject symptomDisplayUI_dizziness;
    public GameObject symptomDisplayUI_musclepain;
    public GameObject symptomDisplayUI_cough;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        symptomDisplayUI.SetActive(false);
        Fever = currentSymptoms.fever;
        Dizziness = currentSymptoms.dizziness;
        MusclePain = currentSymptoms.MusclePain;
        Cough = currentSymptoms.cough;


        //ui
        TextMeshProUGUI feverText = symptomDisplayUI_fever.GetComponent<TextMeshProUGUI>();
        feverText.text = Fever.ToString();

        TextMeshProUGUI dizzinessText = symptomDisplayUI_dizziness.GetComponent<TextMeshProUGUI>();
        dizzinessText.text = Dizziness.ToString();

        TextMeshProUGUI musclePainText = symptomDisplayUI_musclepain.GetComponent<TextMeshProUGUI>();
        musclePainText.text = MusclePain.ToString();

        TextMeshProUGUI coughText = symptomDisplayUI_cough.GetComponent<TextMeshProUGUI>();
        coughText.text = Cough.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
