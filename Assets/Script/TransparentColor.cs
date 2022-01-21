using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentColor : MonoBehaviour
{
    public bool clear;
    // Start is called before the first frame update
    void Start()
    {
        var renderer = this.gameObject.GetComponent<Renderer>();
        var color = renderer.material.color;
        if (clear)
        {
            color.a = 0.0f;
            renderer.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
