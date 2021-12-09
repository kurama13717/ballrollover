using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // 拡大最小値
    private float min_scale = 1.0f;
    // 拡大最大値
    private float max_scale = 2.0f;

    // 現在拡大率
    private float currentScaleValue = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("SceneGame");
    }

    // Update is called once per frame
    void Update()
    {
        
        var scale = gameObject.transform.localScale;

        scale.x += currentScaleValue;
        scale.y += currentScaleValue;

        if (scale.x >= max_scale)
            currentScaleValue = -0.001f;
        else if (scale.x <= min_scale)
            currentScaleValue = 0.001f;

        gameObject.transform.localScale = scale;
    }
}
