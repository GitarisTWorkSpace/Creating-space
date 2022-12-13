using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    public GameObject MoveCameraPanel; // Панель кнопок перемешения камеры

    Quaternion originRotation; // Начальный угол поворота
    float angleHorizontal; // угол по горизонтали
    float angleVertical; // угол по вертикали

    [SerializeField] public float mainSpeed = 0.05f; // скорость перемешения камеры
    [SerializeField] public float camSens = 100f; // скарость врашения камеры

    public bool movementCamera = false; // должна ли варщаться и пермещаться камера 

    private Vector3 StartPositionCamera = new Vector3(0, 7, -10); // начальная позиция камеры
    public Vector3 Speed; // скорость перемешения камеры

    public void CameraONMoveButton()
    {
        if (movementCamera)
            movementCamera = false;
        else if (!movementCamera)
            movementCamera = true;
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

    public void GetButtonFORWADR()
    {
        Speed = new Vector3(0, 0, mainSpeed);
    }

    public void GetButtonBACKWARD()
    {
        Speed = new Vector3(0, 0, -mainSpeed);
    }

    public void GetButtonLEFT()
    {
        Speed = new Vector3(-mainSpeed, 0, 0);
    }

    public void GetButtonRIGHT()
    {
        Speed = new Vector3(mainSpeed, 0, 0);
    }

    public void GetButtonUP()
    {
        Speed = new Vector3(0, mainSpeed, 0);
    }

    public void GetButtonDOWN()
    {
        Speed = new Vector3(0, -mainSpeed, 0);
    }

    public void StartPoition()
    {
        Camera.main.transform.position = StartPositionCamera;
    }

    private void Start()
    {
        originRotation = Camera.main.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (movementCamera)
        {
            angleHorizontal += Input.GetAxis("Mouse X") * camSens;
            angleVertical += Input.GetAxis("Mouse Y") * camSens;

            angleVertical = Mathf.Clamp(angleVertical, -60, 60);
            angleHorizontal = Mathf.Clamp(angleHorizontal, -60, 60);

            Quaternion rotetionX = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
            Quaternion rotetionY = Quaternion.AngleAxis(-angleVertical, Vector3.right);

            Camera.main.transform.rotation = originRotation * rotetionY * rotetionX;
        }

        if (movementCamera)
        {
            Camera.main.transform.position += Speed;
        }

        if (Camera.main.transform.position.z >= 16 || Camera.main.transform.position.z <= -16)
            StartPoition();

        if (Camera.main.transform.position.x >= 16 || Camera.main.transform.position.x <= -16)
            StartPoition();

        if (Camera.main.transform.position.y >= 16 || Camera.main.transform.position.y <= -1)
            StartPoition();
    }
}
