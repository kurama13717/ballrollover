using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    public Text ClearTime;
    public int cleartime;

    // Start is called before the first frame update
    void Start()
    {
        cleartime = PlayerPrefs.GetInt("ƒNƒŠƒAŽžŠÔ", 0);

        ClearTime.text = cleartime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
