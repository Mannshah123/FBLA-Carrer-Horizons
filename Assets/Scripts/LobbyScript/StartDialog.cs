using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public bool isDialogActive;

    public ScreenFader screenFader;
    void Start()
    {
        dialogBox.SetActive(false);
        isDialogActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isDialogActive)
        {
            if (!dialogBox.activeSelf)
            {
                Debug.Log("E Pressed");
                dialogBox.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered trigger");
        if (other.CompareTag("Player"))
        {
            isDialogActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isDialogActive = false;
            dialogBox.SetActive(false);
        }
    }

    public void changeScene()
    {
        Debug.Log("Changing scene");
        screenFader.FadeIn();
    }
}
