using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddForce : MonoBehaviour
{
   
    public Rigidbody rb;
    public float fallout;       // ���Ƃ̋���
    public float coefficient;   // ��C��R�W��
    public float increase;      // �傫���A�����̕ω���
    public float scalelimit;    // �傫������
    [SerializeField]
    float LimitSpeed;
    private bool isDamage { get; set; }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.rb.velocity = new Vector3(0, 0, 0);

    }

    float totalTime = 0.0f;
    float fadeCt = 0;

    void FixedUpdate()
    {
#if false 
        Vector3 force = new Vector3(10f, 0.0f, 0.0f);    // �͂�ݒ�
        //rb.AddForce(force, ForceMode.Force);            // �͂�������
        rb.AddForce(-coefficient * rb.velocity);    // ��C��R�ǉ�

        rb.drag -= increase;   // �R�͌���
        if (rb.drag < -2.0f)
        {
            rb.drag = -2.0f;
        }

        if (rb.velocity.magnitude > LimitSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.2f, rb.velocity.y / 1.0f, rb.velocity.z / 1.2f);
        }


        if(rb.velocity.y>20)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.2f, 10.0f, rb.velocity.z / 1.2f);
        }
#endif
        this.transform.localScale += new Vector3(increase, increase, increase);     // �X�P�[������
        if (this.transform.localScale.x > scalelimit)
            this.transform.localScale = new Vector3(scalelimit, scalelimit, scalelimit);

        

        if (isDamage)   // �_���[�W���󂯂���
        {
            //float level = Mathf.Sin(Time.deltaTime * 6.0f) / 2 + 0.5f;

            fadeCt += 2;
            float level = Mathf.Sin(fadeCt) / 2.0f + 0.5f;
            var renderer = this.gameObject.GetComponent<Renderer>();
            var color = renderer.material.color;
            color.a = level;
            renderer.material.color = color;

            totalTime += Time.deltaTime;
            if (totalTime >= 3.0f) {
                //this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
                color.a = 1.0f;
                renderer.material.color = color;
                totalTime = 0.0f;
                isDamage = false;
            }
        }

        Debug.Log(rb.velocity.magnitude);
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

    void OnTriggerEnter(Collider collider)  // �ǂƂ̓����蔻��
    {
        Transform myTransform = this.transform; // transform���擾
        if (collider.gameObject.name == "Wall")
        {
            isDamage = true;
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            //StartCoroutine(OnDamage());
        }
    }

    public void OnDamage()
    {

        //yield return new WaitForSeconds(3.0f);

        // �ʏ��Ԃɖ߂�
        isDamage = false;
        this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);

    }
}
