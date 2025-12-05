using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPCMedicalScript : MonoBehaviour
{
    public Symptons currentSymptoms;

    public bool Fever;
    public bool Dizziness;
    public bool MusclePain;
    public bool Cough;

    public bool isTreated;



    public GameObject symptomDisplayUI;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        symptomDisplayUI.SetActive(false);
        Fever = currentSymptoms.fever;
        Dizziness = currentSymptoms.dizziness;
        MusclePain = currentSymptoms.MusclePain;
        Cough = currentSymptoms.cough;

        //ui

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
