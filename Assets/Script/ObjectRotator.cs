using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject targetObject;
    public float RotationAngleZ;        // ��]�p�x

    private Camera mainCamera;
    private Vector2 lastMousePosition;  // �}�E�X�̓����̈ʒu
    private float distance_two;         // ��_�Ԃ̋���
    private float prevRotate;           // �O��̊p�x
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

            // ����̊p�x�ƑO��̊p�x�̍����A�p�x�̈ړ���
            var fixRotate = rotate - prevRotate;

            prevRotate = rotate;

            // ���������𔽉f
            var angle = targetObject.transform.localEulerAngles;
            angle.z += fixRotate;
            targetObject.transform.localEulerAngles = angle;

            lastMousePosition = Input.mousePosition;
        }
        //Debug.Log(((Input.mousePosition.x / Screen.width) * 2) - 1.0f);
    }
}
