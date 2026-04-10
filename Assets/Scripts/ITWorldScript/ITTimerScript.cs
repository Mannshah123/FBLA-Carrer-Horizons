using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ITTimerScript : MonoBehaviour
{
   public float time;
   public Text TimerText;
   public Image Fill;
   public float max;
   
    void Update()
    {
        Timer();
    }


    public void Timer(){
        time -= Time.deltaTime;
        TimerText.text = "" + (int)time;
        Fill.fillAmount = time / max;

        if(time <= 0){
            time = 0;
        }
    }
}
