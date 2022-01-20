using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour
{
    [SerializeField]
    Text TimeText;


    // Start is called before the first frame update
    void Start()
    {
        TimeText.text = TimeMana.minute.ToString("00") + ":" + ((int)TimeMana.seconds).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
