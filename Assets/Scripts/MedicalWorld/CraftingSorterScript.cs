using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingSorterScript : MonoBehaviour
{

    public Symptons[] allSymptoms;

    public GameObject craftingOptionPanel;
    public GameObject descriptionPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i =0; i< allSymptoms.Length; i++){
            GameObject descriptionInstance = Instantiate(descriptionPrefab);
            descriptionInstance.transform.SetParent(craftingOptionPanel.transform, false);
            descriptionInstance.GetComponentInChildren<TMP_Text>().text = allSymptoms[i].name;
            Transform textTransform = descriptionInstance.transform.Find("CraftingText");
            textTransform.GetComponent<TMP_Text>().text = allSymptoms[i].name;

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
