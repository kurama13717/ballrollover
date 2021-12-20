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
    public float Timer = 0;
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void OnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            audioSource.Play();
            if (!audioSource.isPlaying) 
            {
                SceneManager.LoadScene("GameScene");
            }            
        }
    }

    // Update is called once per frame
    public void Update()
    {
       
    }
}
