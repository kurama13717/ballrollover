using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        StartCoroutine("ScaleUp");
    }

    void FixedUpdate()
    {
        Vector3 force = new Vector3(0.0f, 0.0f, 10.0f);
        rb.AddForce(force, ForceMode.Force);

    }

    IEnumerator ScaleUp()
    {
        for (float i = 1; i < 3; i += 0.1f)
        {
            this.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
