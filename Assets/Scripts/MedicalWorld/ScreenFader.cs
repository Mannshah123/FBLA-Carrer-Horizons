using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScreenFader : MonoBehaviour
{
   public Image fadeImage;
    public float fadeDuration = 0.5f;

    public IEnumerator FadeOut()
    {
        Debug.Log("Fading out...");
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
    }
}
