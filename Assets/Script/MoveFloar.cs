using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloar : MonoBehaviour
{
    public bool Direction;  // ˆÚ“®Œü‚«
    public float Move;      // °‚ÌˆÚ“®‘¬“x
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = this.gameObject.GetComponent<Renderer>();
        var color = renderer.material.color;
        color.r = 0.3f;
        color.g = 0.3f;
        color.b = 0.8f;
        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        if (Direction)
            counter += Move;
        else
            counter -= Move;
        pos.x = Mathf.Sin(counter) * 0.75f;
        transform.localPosition = pos;
    }
}
