using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HIGHSCORE : MonoBehaviour
{
    private Text timerText; //ハイスコアを表示するText

    int ho = 3;
    float ka = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
        timerText = GetComponentInChildren<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ho < TimeMana.minute)
        {
            timerText.text = ho.ToString("00") + ":" + ka.ToString("00");
        }
        if (ho == TimeMana.minute && ka <= TimeMana.seconds) 
        {
            timerText.text = ho.ToString("00") + ":" + ka.ToString("00");
        }

        if (ho == TimeMana.minute && ka >= TimeMana.seconds)
        {
            int ho = TimeMana.minute;
            float ka = TimeMana.seconds;
            timerText.text = ho.ToString("00") + ":" + ka.ToString("00");
        }
        if (ho > TimeMana.minute) 
        { 
                int ho = TimeMana.minute;
                float ka = TimeMana.seconds;
                timerText.text = ho.ToString("00") + ":" + ka.ToString("00");
        }
       
    }
}

