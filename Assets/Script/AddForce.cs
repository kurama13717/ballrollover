using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddForce : MonoBehaviour
{
   
    public Rigidbody rb;
    public float increase;      // �傫���A�����̕ω���
    public float scalelimit;    // �傫������
    [SerializeField]
    private bool isDamage { get; set; }
    int layerMask = 1 << 6;     // ���̃��C���[
    //int layerMask1 = 1 << 7;    // �ǂ̃��C���[
    float totalTime = 0.0f;
    float fadeCt = 0;
    public Vector3 spheredown = new Vector3(0, -1, 0);

    // ���f�[�^�̍Đ����u���i�[����ϐ�
    private AudioSource audio;

    // ���f�[�^���i�[����ϐ��iInspector�^�u������l��ύX�ł���悤�ɂ���j
    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private AudioClip sound2;
    //public Slider slider;

    //public float fallout;       // ���Ƃ̋���
    //public float coefficient;   // ��C��R�W��
    //float LimitSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.rb.velocity = new Vector3(0, 0, 0);
        Ray ray = new Ray(this.transform.localPosition, spheredown);
        // slider.value = 0;
        audio = gameObject.AddComponent<AudioSource>();

    }


    void FixedUpdate()
    {
        //slider.value += rb.velocity.magnitude * 0.000001f;


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

        // ���C�L���X�g�֘A
        {
            RaycastHit hit;

            // ���Ƃ̓����蔻��
            if (Physics.Raycast(
                this.transform.localPosition,
                spheredown,
                out hit,
                this.transform.localScale.x,
                layerMask))
            {
                // ���C���Փ˂������W
                Vector3 hitPos = hit.point;
                if (hit.point.y - this.transform.localPosition.y < this.transform.localScale.y)
                {
                    this.transform.localPosition = new Vector3(this.transform.localPosition.x, hit.point.y + this.transform.localScale.y, this.transform.localPosition.z);
                }
                //Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.localPosition, spheredown * this.transform.localScale.x / 2, Color.white);
                //Debug.Log("Did not Hit");
                //Debug.Log(this.transform.localScale.x);
            }

            // �ǂƓ���������
            /*if (Physics.Raycast(
                this.transform.localPosition,
                spheredown,
                this.transform.localScale.x,
                layerMask1))
            {
                Debug.Log("Did Hit Wall");
            }*/
        }

        if (isDamage)   // �_���[�W���󂯂���
        {
            fadeCt += 2;
            float level = Mathf.Sin(fadeCt) / 2.0f + 0.5f;
            var renderer = this.gameObject.GetComponent<Renderer>();
            var color = renderer.material.color;
            color.a = level;
            renderer.material.color = color;

            totalTime += Time.deltaTime;
            if (totalTime >= 3.0f) {
                color.a = 1.0f;
                renderer.material.color = color;
                totalTime = 0.0f;
                isDamage = false;
            }
        }

        //Debug.Log(rb.velocity.magnitude);

        Gauge.vel = rb.velocity.magnitude;
        Debug.Log(Gauge.vel / 25.0f);
    }


    void OnCollisionEnter(Collision collision) // ��������̏��Ƃ̓����蔻��
    {
        Transform myTransform = this.transform; // transform���擾
        Vector3 pos = myTransform.localPosition;     // ���W���擾
        if (collision.gameObject.name == "Fall judgment") // �Ԃ���������̖��O���擾(���ɗ�������)
        {
            this.rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);           // ���x�������l�ɖ߂�
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            pos.x = 0.0f;                       // ���X�|�[�����W y
            pos.y += 70.0f;                     // ���X�|�[�����W y
            myTransform.localPosition = pos;    // ���W��ݒ�
            audio.PlayOneShot(sound2); //������
        }

        if (collision.gameObject.name == "Judgment Chain") // �Ԃ���������̖��O���擾(���ɗ�������)
        {
            this.rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);           // ���x�������l�ɖ߂�
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            pos.x = 10.0f;                      // ���X�|�[�����W y
            pos.y += 70.0f;                     // ���X�|�[�����W y
            myTransform.localPosition = pos;    // ���W��ݒ�
        }

        if (collision.gameObject.name == "Goal judgment") // �Ԃ���������̖��O���擾(���ɗ�������)
        {
            this.rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);           // ���x�������l�ɖ߂�
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            pos.x = 0.0f;                       // ���X�|�[�����W y
            pos.y = -700.0f;                    // ���X�|�[�����W y
            pos.z = 2100.0f;
            myTransform.localPosition = pos;    // ���W��ݒ�
        }
    }

    void OnTriggerEnter(Collider collider)  // �ǂƂ̓����蔻��
    {
        Transform myTransform = this.transform; // transform���擾
        if (collider.gameObject.name == "Wall")
        {
            isDamage = true;
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // �傫���������l�ɖ߂�
            this.rb.velocity = new Vector3(0.0f, 0.0f, 10.0f);
            audio.PlayOneShot(sound);//�Փˉ�
            //StartCoroutine(OnDamage());
        }
    }
}
