using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    // Start is called before the first frame update
    float counter = 0;

    void Start()
    {
       
    }

   

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;

        counter += 0.01f;

        pos.x = Mathf.Sin(counter);

        transform.localPosition = pos;
    }
}
