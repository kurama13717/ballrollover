using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        
    }
    float TotalTimer = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        TotalTimer++;

        if (TotalTimer > 720.0f && StartButton.StSe == 1)
        {
            SceneManager.LoadScene("SelectScene");
        }

        if (TotalTimer > 720.0f && SelectStage1.SeSt1 == 1) 
        {
            SceneManager.LoadScene("GameScene1");
        }

        if (TotalTimer > 720.0f && SelectStage2.SeSt2 == 1)
        {
            SceneManager.LoadScene("GameScene2");
        }

    }
}
