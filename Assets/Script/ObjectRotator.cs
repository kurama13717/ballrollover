using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject targetObject;
    public float RotationAngleZ;        // 回転角度

    private Camera mainCamera;
    private Vector2 lastMousePosition;  // マウスの動作後の位置
    private float distance_two;         // 二点間の距離
    private float prevRotate;           // 前回の角度
    private Vector3 currentAngle;

    void Start()
    {
        mainCamera = Camera.main;

        currentAngle = targetObject.transform.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;

            prevRotate = (((Input.mousePosition.x / Screen.width) * 2) - 1.0f) * -RotationAngleZ;

        }
        else if (Input.GetMouseButton(0))
        {

            var rotate = (((Input.mousePosition.x / Screen.width) * 2) - 1.0f) * -RotationAngleZ;

            // 今回の角度と前回の角度の差分、角度の移動量
            var fixRotate = rotate - prevRotate;

            prevRotate = rotate;

            // 差分だけを反映
            var angle = targetObject.transform.localEulerAngles;
            angle.z += fixRotate;
            targetObject.transform.localEulerAngles = angle;

            lastMousePosition = Input.mousePosition;
        }
        //Debug.Log(((Input.mousePosition.x / Screen.width) * 2) - 1.0f);
    }
}
