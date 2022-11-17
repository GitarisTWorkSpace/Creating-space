using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Quaternion originRotation;

    float angleX;
    float angleY;
    float canSen = 5f;
    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        angleX += Input.GetAxis("Mouse X") * canSen;
        angleY += Input.GetAxis("Mouse Y") * canSen;

        angleY = Mathf.Clamp(angleY, -80, 80);
        angleX = Mathf.Clamp(angleX, -270, 270);

        Quaternion rotetionY = Quaternion.AngleAxis(angleY, Vector3.up);
        Quaternion rotetionX = Quaternion.AngleAxis(-angleX, Vector3.right);

        Camera.main.transform.rotation = originRotation * rotetionY * rotetionX;
    }
}
