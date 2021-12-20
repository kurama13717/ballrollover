using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{    
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyDown("space"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
        }
    }

        // Update is called once per frame
        public void Update()
    {
//        
//        }

        //var scale = gameObject.transform.localScale;

        //scale.x += currentScaleValue;
        //scale.y += currentScaleValue;

        //if (scale.x >= max_scale)
        //    currentScaleValue = -0.005f;
        //else if (scale.x <= min_scale)
        //    currentScaleValue = 0.005f;

        //gameObject.transform.localScale = scale;
    }
}
