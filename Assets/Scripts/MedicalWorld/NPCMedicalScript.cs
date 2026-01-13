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
    

    public CraftingSorterScript craftingSorterScript;

    void Awake()
    {
        craftingSorterScript = GameObject.Find("CraftingButtonManager").GetComponent<CraftingSorterScript>();
    }
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
        if(Input.GetMouseButtonDown(0))
        {
            DetectNPCClick();
        }


        if(isTreated)
        {
            Destroy(gameObject);
        }
    }


    void DetectNPCClick()
{
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

    if (hit.collider != null && hit.collider.gameObject == gameObject)
    {
        Debug.Log("NPC clicked: " + gameObject.name);
        //logic
        if(craftingSorterScript.craftedSymptom == currentSymptoms)
        {
            Debug.Log("NPC Treated Successfully!");
            isTreated = true;
        }
        else
        {
           
        }
    }
}
}
