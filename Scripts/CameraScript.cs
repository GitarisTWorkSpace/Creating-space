using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    public float mainSpeed = 100.0f;
    public float camSens = 0.25f;

    public bool rotateOnlyIfMousedown = true;

    private Vector3 lastMouse = new Vector3(255, 255, 255);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            lastMouse = Input.mousePosition;
        if (!rotateOnlyIfMousedown || rotateOnlyIfMousedown && Input.GetMouseButton(0))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
    }
}
