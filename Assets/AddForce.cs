using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Rigidbody rb;
    public float coefficient;   // ��C��R�W��
    public float increase;      // �傫���A�����̕ω���

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-coefficient * rb.velocity);    // ��C��R�ǉ�
        rb.drag -= increase;   // �R�͌���
        if (rb.drag < -2.0f)
            rb.drag = -2.0f;
        this.transform.localScale += new Vector3(increase, increase, increase);     // �X�P�[������
        if (this.transform.localScale.x > 2.0f)
            this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }
}
