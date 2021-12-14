using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddForce : MonoBehaviour
{
   
    public Rigidbody rb;
    public float fallout;       // 床との距離
    public float coefficient;   // 空気抵抗係数
    public float increase;      // 大きさ、速さの変化量
    public 

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.rb.velocity = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        rb.AddForce(-coefficient * rb.velocity);    // 空気抵抗追加
        rb.drag -= increase;   // 抗力減少
        if (rb.drag < -2.0f)
            rb.drag = -2.0f;
        this.transform.localScale += new Vector3(increase, increase, increase);     // スケール増加
        if (this.transform.localScale.x > 2.0f)
            this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    
    void OnCollisionEnter(Collision collision) // 落下判定の床との当たり判定
    {
        Transform myTransform = this.transform; // transformを取得
        Vector3 pos = myTransform.position;     // 座標を取得
        if (collision.gameObject.name == "Fall judgment") // ぶつかった相手の名前を取得(穴に落ちた時)
        {
            this.rb.velocity = new Vector3(0, 0, 0);    // 速度を初期値に戻す
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // 大きさを初期値に戻す
            pos.y += 20;                 // リスポーン座標 y
            myTransform.position = pos;  // 座標を設定
        }
                
    }
}
