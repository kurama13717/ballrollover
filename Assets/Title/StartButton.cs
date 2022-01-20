using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UniRx.Triggers;
using UniRx;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    //public AudioClip Decision;
    public static int StSe;
    // Start is called before the first frame update
    public void Start()
    {
        StSe = 0;
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StSe = 1;
            SceneManager.LoadScene("SceneLoading");     
        }
    }

    // Update is called once per frame
    public void Update()
    {
       
    }
}
