using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int seconds;
    int minutes;
   public Text timerText;
    public Score score;

    // Update is called once per frame
    private void Start()
    {
        minutes = 0;
        seconds = 0;
        StartCoroutine(SecondsCounterCoroutine());
    }


    IEnumerator SecondsCounterCoroutine()
    {
        while(true)
        {
            
            if(seconds==60)
            {
                seconds = 0;
                minutes = 1;
            }
         
            if(minutes<10)
            {
                timerText.text = "0"+ minutes.ToString();
            }else
            {
                timerText.text = minutes.ToString();
            }
            if (seconds < 10)
            {
                timerText.text += " : 0" + seconds.ToString();
            }
            else
            {
                timerText.text += " : "+ seconds.ToString();
            }
            seconds += 1;
            score.value += 1;
            yield return new WaitForSeconds(1);
        }
    }
  public void ResetTimer()
    {
        seconds = 0;
        minutes = 0;
    }

}