using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Joystick MoveJoystick;
    public Joystick AimJoystick;

    float PlayerRunSpeed = 1f;

    Vector3 PlayerAimPos;

    private void Update()
    {
        PlayerMove();
        PlayerAim();
    }

    void PlayerMove()
    {
        if (MoveJoystick.transform.GetChild(0).gameObject.activeSelf == false) return;

        transform.Translate(MoveJoystick.Horizontal * Time.deltaTime * PlayerRunSpeed, 0, MoveJoystick.Vertical * Time.deltaTime * PlayerRunSpeed, Space.World);
        PlayerAimPos = transform.position + new Vector3(MoveJoystick.Horizontal, 0, MoveJoystick.Vertical);
        transform.LookAt(PlayerAimPos);
    }

    void PlayerAim()
    {
        if (AimJoystick.transform.GetChild(0).gameObject.activeSelf == false) return;

        PlayerAimPos = transform.position + new Vector3(AimJoystick.Horizontal, 0, AimJoystick.Vertical);
        transform.LookAt(PlayerAimPos);
    }
}
