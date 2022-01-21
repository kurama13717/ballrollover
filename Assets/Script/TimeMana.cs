using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeMana : MonoBehaviour
{
	public static int minute;
	public static float seconds;
	//�@�O��Update�̎��̕b��
	private float oldSeconds;
	//�@�^�C�}�[�\���p�e�L�X�g
	//private text timerText;
	private Text timerText;

	void Start()
	{
		minute = 2;
		seconds = 20.0f;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
	}

	void Update()
	{
		seconds += Time.deltaTime;
		if (seconds >= 60f)
		{
			minute++;
			seconds = seconds - 60;
		}
		//�@�l���ς�����������e�L�X�gUI���X�V
		if ((int)seconds != (int)oldSeconds)
		{
			timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		}
		oldSeconds = seconds;
	}
}
