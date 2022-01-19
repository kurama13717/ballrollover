using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WitchRetry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (SelectStage2.SeSt2 == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }

        if (SelectStage1.SeSt1 == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }


}
