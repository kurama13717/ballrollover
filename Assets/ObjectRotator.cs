using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 rotationSpeed = new Vector3(0.1f, 0.2f, 0.1f);   // ��]���x
    public bool reverse;    // �t��]�t���O
    public float RotationAngleZ;    // ��]�p�x���

    private Camera mainCamera;
    private Vector2 lastMousePosition;      // �}�E�X�̓����̈ʒu

    void Start()
    {
        mainCamera = Camera.main;
    }

    private Vector3 newAngle = Vector3.zero;

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
                //var newAngle = Vector3.zero;
                var x = (Input.mousePosition.x - lastMousePosition.x);

                newAngle.z = x * rotationSpeed.x;

                var rotate = targetObject.transform.localEulerAngles;
                rotate.z = newAngle.z;

                if (rotate.z < 0 - RotationAngleZ)
                    rotate.z = 0 - RotationAngleZ;
                else if (RotationAngleZ < rotate.z)
                    rotate.z = RotationAngleZ;

                targetObject.transform.localEulerAngles = rotate;

                //targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (lastMousePosition.x - Input.mousePosition.x);

                //var newAngle = Vector3.zero;
                newAngle.z = x * rotationSpeed.x;

                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
