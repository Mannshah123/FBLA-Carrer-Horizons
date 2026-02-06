// ButtonHoverScale.cs - Attach to any UI Button
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scale Settings")]
    public float hoverScale = 1.1f;      // How much bigger (1.1 = 110% size)
    public float animationSpeed = 5f;     // How fast it scales
    
    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isHovering = false;
    
    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }
    
    void Update()
    {
        // Smoothly animate to target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Mouse entered button
        isHovering = true;
        targetScale = originalScale * hoverScale;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        // Mouse left button
        isHovering = false;
        targetScale = originalScale;
    }
}