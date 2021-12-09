using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // �g��ŏ��l
    private float min_scale = 1.0f;
    // �g��ő�l
    private float max_scale = 2.0f;
    // �}�E�X���d�Ȃ��Ă���Ƃ�
    private bool MouseOverlap = false;
    // ���݊g�嗦
    private float currentScaleValue = 0.005f;


    GameObject startbutton;


    // Start is called before the first frame update
    public void Start()
    {
       startbutton = GameObject.Find("StartButton"); 
    }
    public void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
    
    }


    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("GameScene");
        }

       
            var scale = gameObject.transform.localScale;

            scale.x += currentScaleValue;
            scale.y += currentScaleValue;

            if (scale.x >= max_scale)
                currentScaleValue = -0.005f;
            else if (scale.x <= min_scale)
                currentScaleValue = 0.005f;

            gameObject.transform.localScale = scale;

        
       
    }
}
