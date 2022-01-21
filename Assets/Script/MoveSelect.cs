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
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("SceneLoading");
        }
    }
}
