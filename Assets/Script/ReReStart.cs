using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReReStart : MonoBehaviour
{
    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Update()
    {
       
    }
}



