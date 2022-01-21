using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{

    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
          timerText.text = TimeMana.minute.ToString("00") + ":" + ((int)TimeMana.seconds).ToString("00");
    }
}
