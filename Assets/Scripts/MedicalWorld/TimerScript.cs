// StarRatingTimer.cs - Timer with star rating based on completion time
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    [Header("Timer Settings")]
    public float threeStarTime = 30f;    // Complete in 30 seconds = 3 stars
    public float twoStarTime = 60f;      // Complete in 60 seconds = 2 stars
    public float oneStarTime = 90f;      // Complete in 90 seconds = 1 star
    
    [Header("UI References")]
    public TMP_Text timerText;
    public GameObject winPanel;          // Panel to show when level complete
    public Image[] stars;                // Array of 3 star images
    public TMP_Text completionTimeText;  // Shows final time
    
    [Header("Star Sprites")]
    public Sprite starFilled;            // Filled/gold star
    public Sprite starEmpty;             // Empty/gray star
    
    [Header("Colors")]
    public Color threeStarColor = Color.yellow;
    public Color twoStarColor = Color.cyan;
    public Color oneStarColor = Color.white;
    
    private float currentTime = 0f;
    private bool isRunning = false;
    private bool levelComplete = false;
    private int starsEarned = 0;
    
    void Start()
    {
        // Hide win panel at start
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        
        // Start timer
        
    }
    
    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int hours = Mathf.FloorToInt(currentTime / 3600);
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            
            if (hours > 0)
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            else
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
        levelComplete = false;
    }
    
    public void CompleteLevel()
    {
        if (levelComplete) return;
        
        isRunning = false;
        levelComplete = true;
        
        // Calculate stars earned
        CalculateStars();
        
        // Show win panel with stars
        StartCoroutine(ShowWinPanel());
    }
    
    void CalculateStars()
    {
        if (currentTime <= threeStarTime)
        {
            starsEarned = 3;
        }
        else if (currentTime <= twoStarTime)
        {
            starsEarned = 2;
        }
        else if (currentTime <= oneStarTime)
        {
            starsEarned = 1;
        }
        else
        {
            starsEarned = 0; // No stars if too slow
        }
        
        Debug.Log("Level completed in " + currentTime + " seconds. Stars earned: " + starsEarned);
    }
    
    public IEnumerator ShowWinPanel()
    {
        Debug.Log("Showing win panel with " + starsEarned + " stars.");
        // Show the panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        
        // Display completion time
        if (completionTimeText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            completionTimeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        // Reset all stars to empty
        foreach (Image star in stars)
        {
            star.sprite = starEmpty;
            star.transform.localScale = Vector3.zero;
        }
        
        // Animate stars one by one
        for (int i = 0; i < starsEarned; i++)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(AnimateStar(stars[i]));
        }
    }
    
    IEnumerator AnimateStar(Image star)
    {
        // Change to filled star
        star.sprite = starFilled;
        
        // Set color based on star count
        if (starsEarned == 3)
            star.color = threeStarColor;
        else if (starsEarned == 2)
            star.color = twoStarColor;
        else
            star.color = oneStarColor;
        
        // Pop-in animation
        float elapsed = 0f;
        float duration = 0.3f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1.2f, elapsed / duration);
            star.transform.localScale = Vector3.one * scale;
            yield return null;
        }
        
        // Bounce back to normal size
        elapsed = 0f;
        duration = 0.15f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float scale = Mathf.Lerp(1.2f, 1f, elapsed / duration);
            star.transform.localScale = Vector3.one * scale;
            yield return null;
        }
        
        star.transform.localScale = Vector3.one;
    }
    
    // Public method to get stars earned
    public int GetStarsEarned()
    {
        return starsEarned;
    }
    
    // Public method to get completion time
    public float GetCompletionTime()
    {
        return currentTime;
    }
}