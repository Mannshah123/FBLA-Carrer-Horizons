using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingSorterScript : MonoBehaviour
{

    public Symptons[] allSymptoms;

    //medicine
    public GameObject antidoteName;
    public GameObject antidoteDescription;
   
    public GameObject antidoteImage;

    public GameObject antidoteButton;


    //syringe
    public GameObject syringeName;
    public GameObject syringeDescription;
    public GameObject syringeImage;
    public GameObject syringeButton;

    //mix
    public GameObject mixName;
    public GameObject mixDescription;
    public GameObject mixImage;
    public GameObject mixButton;

    //inventory
    public GameObject inventoryPanel;

    public void SetAntidote()
    {
       
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        for(int i = 0; i < allSymptoms.Length; i++)
        {
           if (allSymptoms[i] != null && buttonName == allSymptoms[i].name)
        {
            if (i <= 4)
            {
                // Antidote logic
                antidoteName.SetActive(true);
                antidoteDescription.SetActive(true);
                antidoteImage.SetActive(true);
                antidoteButton.SetActive(true);

                antidoteName.GetComponent<TMP_Text>().text = allSymptoms[i].name;
                antidoteDescription.GetComponent<TMP_Text>().text = allSymptoms[i].description;
            }
            else if (i >= 5 && i <= 9)
            {
                // Mix logic
                mixName.SetActive(true);
                mixDescription.SetActive(true);
                mixImage.SetActive(true);
                mixButton.SetActive(true);

                mixName.GetComponent<TMP_Text>().text = allSymptoms[i].name;
                mixDescription.GetComponent<TMP_Text>().text = allSymptoms[i].description;
            }
            else if (i >= 10)
            {
                // Syringe logic
                syringeName.SetActive(true);
                syringeDescription.SetActive(true);
                syringeImage.SetActive(true);
                syringeButton.SetActive(true);

                syringeName.GetComponent<TMP_Text>().text = allSymptoms[i].name;
                syringeDescription.GetComponent<TMP_Text>().text = allSymptoms[i].description;
            }
        }
            


        }
    }



    
}
