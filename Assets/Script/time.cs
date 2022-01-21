using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //’Ç‰Á
public class time : MonoBehaviour
{
    public float timer = 0;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text textObject_text = textObject.GetComponent < Text>();
        timer += Time.deltaTime;
        textObject_text.text = timer.ToString("F2");

    }
}
