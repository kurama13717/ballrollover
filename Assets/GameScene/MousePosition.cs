using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

	Vector3 mouse;
	Vector3 mouse3d;

	// Use this for initialization
	void Start()
	{
	}
	// Update is called once per frame
	void Update()
	{
		mouse = Input.mousePosition;
		//mouse.x = 
		mouse.z = 40f;
		mouse3d = Camera.main.ScreenToWorldPoint(mouse);
		transform.position = mouse3d;
	}
}