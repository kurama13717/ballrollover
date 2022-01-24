using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneLoading : MonoBehaviour
{

    float TotalTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalTimer++;
        if (TotalTimer > 360.0f && MoveSelect.SeSt == 1)
        {
            SceneManager.LoadScene("SelectScene");
        }
        if (TotalTimer > 360.0f && SelectStage1.SeSt1 == 1)
        {
            SceneManager.LoadScene("GameScene11");
        }
        if (TotalTimer > 360.0f && SelectStage2.SeSt2 == 1)
        {
            SceneManager.LoadScene("GameScene5");
        }
    }
}
