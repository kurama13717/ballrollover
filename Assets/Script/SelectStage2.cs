using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectStage2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static int SeSt2;


    void Start()
    {
        SeSt2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SeSt2 = 1;
            SceneManager.LoadScene("GameScene2");

        }
    }

}
