using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddForce : MonoBehaviour
{
   
    public Rigidbody rb;
    public float increase;      // 大きさ、速さの変化量
    public float scalelimit;    // 大きさ制限
    [SerializeField]
    private bool isDamage { get; set; }
    int layerMask = 1 << 6;     // 床のレイヤー
    int layerMask1 = 1 << 7;    // 壁のレイヤー
    float totalTime = 0.0f;
    float fadeCt = 0;
    public Vector3 spheredown = new Vector3(0, -1, 0);

    //public float fallout;       // 床との距離
    //public float coefficient;   // 空気抵抗係数
    //float LimitSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        this.rb.velocity = new Vector3(0, 0, 0);
    }


    void FixedUpdate()
    {
#if false 
        Vector3 force = new Vector3(10f, 0.0f, 0.0f);    // 力を設定
        //rb.AddForce(force, ForceMode.Force);            // 力を加える
        rb.AddForce(-coefficient * rb.velocity);    // 空気抵抗追加

        rb.drag -= increase;   // 抗力減少
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
        this.transform.localScale += new Vector3(increase, increase, increase);     // スケール増加
        if (this.transform.localScale.x > scalelimit)
            this.transform.localScale = new Vector3(scalelimit, scalelimit, scalelimit);

        // レイキャスト関連
        {

            // 床との当たり判定
            if (Physics.Raycast(
                this.transform.position,
                spheredown,
                this.transform.localScale.x,
                layerMask))
            {
                //Debug.DrawRay(transform.position, this.transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, spheredown * this.transform.localScale.x / 2, Color.white);
                Debug.Log("Did not Hit");
                //Debug.Log(this.transform.localScale.x);
            }

            // 壁と当たった時
            /*if (Physics.Raycast(
                this.transform.position,
                spheredown,
                this.transform.localScale.x,
                layerMask1))
            {
                Debug.Log("Did Hit Wall");
            }*/
        }

        if (isDamage)   // ダメージを受けた時
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

    void OnTriggerEnter(Collider collider)  // 壁との当たり判定
    {
        Transform myTransform = this.transform; // transformを取得
        if (collider.gameObject.name == "Wall")
        {
            isDamage = true;
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  // 大きさを初期値に戻す
            //StartCoroutine(OnDamage());
        }
    }
}
