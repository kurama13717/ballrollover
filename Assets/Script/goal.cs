using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Transform myTransform = this.transform; // transform���擾
        Vector3 pos = myTransform.localPosition;     // ���W���擾
        if (collider.gameObject.name == "Sphere") // �Ԃ���������̖��O���擾(���ɗ�������)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }

    void OnCollisionEnter(Collision collision) // ��������̏��Ƃ̓����蔻��
    {
        
      
    }

}
