using UnityEngine;

using UnityEngine.UI; //�ǉ�

public class text : MonoBehaviour
{
    public GameObject textObject;
    private GameObject player;

    void Start()
    {
        this.player = GameObject.Find("Sphere");

    }


    void Update()
    {   //Text�I�u�W�F�N�g����R���|�[�l���g���擾����
        Text textObject_text = textObject.GetComponent<Text>();
        Rigidbody rd2 = player.transform.GetComponent<Rigidbody>();
        //sphere�I�u�W�F�N�g���瑬���i���x�̑傫���j���擾����
        float vel = rd2.velocity.magnitude;
        int vel2 = (int)vel;
        //float�^�𕶎���ɕύX����
        string vel_String = vel2.ToString();
        //�\��������e���w�肷��
        textObject_text.text = vel_String+"m";
    }
}
