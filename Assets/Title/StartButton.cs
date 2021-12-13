using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UniRx.Triggers;
using UniRx;

public class StartButton : MonoBehaviour
{
    // Šg‘åÅ¬’l
    private float min_scale = 1.0f;
    // Šg‘åÅ‘å’l
    private float max_scale = 2.0f;

    // Œ»ÝŠg‘å—¦
    private float currentScaleValue = 0.005f;

    private bool TouchFlag = false;

    [SerializeField]
    private Button m_btn;

    // Start is called before the first frame update
    public void Start()
    {
        m_btn.OnPointerDownAsObservable().Subscribe(_ => { OnPointerDown(); });
        m_btn.OnPointerUpAsObservable().Subscribe(_ => { OnPointerUp(); });
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchFlag = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            TouchFlag = false;
            var scale = gameObject.transform.localScale;
            scale.x = 1.0f;
            scale.y = 1.0f;
            gameObject.transform.localScale = scale;
            SceneManager.LoadScene("GameScene");
        }

        if (TouchFlag == true) 
        {
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

#if true
    private void OnPointerDown() {

        TouchFlag = true;
    }

    private void OnPointerUp() {

        TouchFlag = false;
        var scale = gameObject.transform.localScale;
        scale.x = 1.0f;
        scale.y = 1.0f;
        gameObject.transform.localScale = scale;
        SceneManager.LoadScene("GameScene");
    }
#endif
}
