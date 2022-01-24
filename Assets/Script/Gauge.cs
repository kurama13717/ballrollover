using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField]
    Image image;

    static public float vel;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = vel / 25.0f;
    }
}