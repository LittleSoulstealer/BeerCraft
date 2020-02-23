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
        seconds = -1;
        StartCoroutine(SecondsCounterCoroutine());
    }


    IEnumerator SecondsCounterCoroutine()
    {
        while(true)
        {
            seconds += 1;
            score.value += 1;
            if(seconds==60)
            {
                seconds = 0;
                minutes = 1;
            }
         
            timerText.text = minutes.ToString() +" : "+ seconds.ToString();
            yield return new WaitForSeconds(1);
        }
    }
  public void ResetTimer()
    {
        seconds = -1;
        minutes = 0;
    }

}