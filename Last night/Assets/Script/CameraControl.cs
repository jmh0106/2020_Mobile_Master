using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Joystick MoveJoyStick;

    Vector3 PlayerPos;
    Vector3 CameraPos;

    private void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        PlayerPos = GameObject.Find("Player").transform.position;
        CameraPos = PlayerPos + new Vector3(0, 10, -10) /*+ new Vector3(MoveJoyStick.Horizontal, 0, MoveJoyStick.Vertical)*/;
        transform.position = CameraPos;
    }
}
