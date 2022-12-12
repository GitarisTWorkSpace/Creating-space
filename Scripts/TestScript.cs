using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Quaternion originRotation; // Начальный угол поворота
    float angleHorizontal; // угол по горизонтали
    float angleVertical; // угол по вертикали

    [SerializeField] public float camSens = 1f; // скарость врашения камеры
    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        angleHorizontal += Input.GetAxis("Mouse X") * camSens;
        angleVertical += Input.GetAxis("Mouse Y") * camSens;

        angleVertical = Mathf.Clamp(angleVertical, -60, 60);
        angleHorizontal = Mathf.Clamp(angleHorizontal, -60, 60);

        Quaternion rotetionX = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
        Quaternion rotetionY = Quaternion.AngleAxis(-angleVertical, Vector3.right);

        Camera.main.transform.rotation = originRotation * rotetionY * rotetionX;
    }

}
