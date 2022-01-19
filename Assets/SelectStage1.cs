using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectStage1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static int SeSt1;


    void Start()
    {
        SeSt1 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SeSt1 = 1;
            SceneManager.LoadScene("GameScene1");

        }
    }

}
