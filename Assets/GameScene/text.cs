using UnityEngine;

using UnityEngine.UI; //追加

public class text : MonoBehaviour
{
    public GameObject textObject;
    private GameObject player;

    void Start()
    {
        this.player = GameObject.Find("Sphere");

    }


    void Update()
    {   //Textオブジェクトからコンポーネントを取得する
        Text textObject_text = textObject.GetComponent<Text>();
        Rigidbody rd2 = player.transform.GetComponent<Rigidbody>();
        //sphereオブジェクトから速さ（速度の大きさ）を取得する
        float vel = rd2.velocity.magnitude;
        int vel2 = (int)vel;
        //float型を文字列に変更する
        string vel_String = vel2.ToString();
        //表示する内容を指定する
        textObject_text.text = vel_String+"m";
    }
}
