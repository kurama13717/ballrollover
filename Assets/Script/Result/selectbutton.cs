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
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        

    }
}
