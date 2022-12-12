using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    public GameObject MoveCameraPanel; // Панель кнопок перемешения камеры

    public Transform target; // объект вокруг которого должна крутиться камера

    public float mainSpeed = 100.0f; // скорость перемешения камеры
    public float camSens = 0.25f; // скарость врашения камеры

    public bool rotateOnlyIfMousedown = false; // должна ли варщаться камера 

    private Vector3 StartPositionCamera = new Vector3(0, 7, -10);
    public Vector3 Speed; // скорость перемешения камеры

    private Vector3 lastMouse = new Vector3(255, 255, 255);

    private string pos;

    public void CameraONMoveButton()
    {
        if (rotateOnlyIfMousedown)
            rotateOnlyIfMousedown = false;
        else if (!rotateOnlyIfMousedown)
            rotateOnlyIfMousedown = true;
    }

    public void MoveCameraPanelSetActive()
    {
        if (MoveCameraPanel.active)
            MoveCameraPanel.SetActive(false);
        else if (!MoveCameraPanel.active)
            MoveCameraPanel.SetActive(true);
    }

    public void Stop()
    {
        Speed = new Vector3(0, 0, 0);
    }

    public void GetButtonUP()
    {
        Speed = new Vector3(0, 0, 0.05f);
    }

    public void GetButtonDOWN()
    {
        Speed = new Vector3(0, 0, -0.05f);
    }

    public void GetButtonLEFT()
    {
        Speed = new Vector3(-0.05f, 0, 0);
    }

    public void GetButtonRIGHT()
    {
        Speed = new Vector3(0.05f, 0, 0);
    }

    public void StartPoition()
    {
        Camera.main.transform.position = StartPositionCamera;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            lastMouse = Input.mousePosition;
        if (/*!rotateOnlyIfMousedown ||*/ rotateOnlyIfMousedown && Input.GetMouseButton(0))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(Camera.main.transform.eulerAngles.x + lastMouse.x, Camera.main.transform.eulerAngles.y + lastMouse.y, 0);
            Camera.main.transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }

        if (rotateOnlyIfMousedown)
        {
            Camera.main.transform.position += Speed;
        }

        if (Camera.main.transform.position.z >= 16 || Camera.main.transform.position.z <= -16)
            StartPoition();

        if (Camera.main.transform.position.x >= 16 || Camera.main.transform.position.x <= -16)
            StartPoition();

    }
}
