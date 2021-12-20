using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject targetObject;
    public bool reverse;    // �t��]�t���O
    public float RotationAngleZ;    // ��]�p�x���
    public float speed;     // ����

    private Camera mainCamera;
    private Vector2 lastMousePosition;      // �}�E�X�̓����̈ʒu
    private float distance_two;     // ��_�Ԃ̋���

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var rotate = targetObject.transform.localEulerAngles;
                rotate.z = (((Input.mousePosition.x / Screen.width) * 2) - 1.0f) * RotationAngleZ;
                targetObject.transform.localEulerAngles =
                    Vector2.Lerp(rotate, lastMousePosition, Move(rotate, lastMousePosition));
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var rotate = targetObject.transform.localEulerAngles;
                rotate.z = (((Input.mousePosition.x / Screen.width) * 2) - 1.0f) * -RotationAngleZ;
                targetObject.transform.localEulerAngles = rotate;

                lastMousePosition = Input.mousePosition;
            }
        }
        Debug.Log(((Input.mousePosition.x / Screen.width) * 2) - 1.0f);
    }

    float Move(Vector2 position1,Vector2 position2)
    {
        distance_two = Vector2.Distance(position1,position2);
        float Location = (Time.time * speed) / distance_two;
        return Location;
    }
}
