using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalResult2 : MonoBehaviour
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
        Transform myTransform = this.transform; // transformを取得
        Vector3 pos = myTransform.localPosition;     // 座標を取得
        if (collider.gameObject.name == "Sphere") // ぶつかった相手の名前を取得(穴に落ちた時)
        {
            SceneManager.LoadScene("ResultScene2");
        }
    }

}
