using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddForce : MonoBehaviour
{
   
    public Rigidbody rb;
    public float fallout;       // ���Ƃ̋���
    public float coefficient;   // ��C��R�W��
    public float increase;      // �傫���A�����̕ω���
    public 

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.rb.velocity = new Vector3(0, 0, 0);
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

    
    void OnCollisionEnter(Collision collision) // ��������̏��Ƃ̓����蔻��
    {
        Transform myTransform = this.transform; // transform���擾
        Vector3 pos = myTransform.position;     // ���W���擾
        if (collision.gameObject.name == "Fall judgment") // �Ԃ���������̖��O���擾(���ɗ�������)
        {
            this.rb.velocity = new Vector3(0, 0, 0);    // ���x�������l�ɖ߂�
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            pos.y += 20;                 // ���X�|�[�����W y
            myTransform.position = pos;  // ���W��ݒ�
        }
                
    }
}
