using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UniRx.Triggers;
using UniRx;


public class MoveSelect : MonoBehaviour
{

    public static int SeSt;



    // Start is called before the first frame update
    void Start()
    {
        SeSt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SeSt = 1;
            SceneManager.LoadScene("SceneLoading");
        }
    }
}
