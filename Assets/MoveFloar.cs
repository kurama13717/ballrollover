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
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        if (Direction)
            counter += Move;
        else
            counter -= Move;
        pos.x = Mathf.Sin(counter);
        transform.localPosition = pos;
    }
}
