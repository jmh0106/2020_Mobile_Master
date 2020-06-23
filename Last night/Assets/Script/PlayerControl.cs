using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{

}

public class PlayerControl : MonoBehaviour
{
    enum _PlayerState { Idle, Shoot, Reload };
    _PlayerState PlayerState = _PlayerState.Idle;

    [System.Serializable]
    public struct Gun
    {
        public string Name;
        public int NowBullet;
        public int MaxBullet;
        public int TotalBullet;
        public bool isActive;

        public Gun(string _name, int _MaxBullet)
        {
            Name = _name;
            NowBullet = 0;
            MaxBullet = _MaxBullet;
            TotalBullet = 0;
            isActive = false;
        }

        public void ReloadingGun()
        {
            if (NowBullet > MaxBullet) return;
            if (TotalBullet <= 0) return;

            Debug.Log("ReloadingGun");

            if (NowBullet == 0)
            {
                if (TotalBullet > MaxBullet)
                {
                    TotalBullet -= MaxBullet;
                    NowBullet = MaxBullet;
                }
                else
                {
                    NowBullet = TotalBullet;
                    TotalBullet = 0;
                }
            }
            else
            {
                int GabBullet = MaxBullet + 1 - NowBullet;

                if (GabBullet < TotalBullet)
                {
                    TotalBullet -= GabBullet;
                    NowBullet = MaxBullet + 1;
                }
                else
                {
                    NowBullet += TotalBullet;
                    TotalBullet = 0;
                }
            }
        }

        public void ShootingGun()
        {
            if (NowBullet <= 0) return;
            NowBullet--;
            Debug.Log("ShootingGun" + NowBullet);
        }
    }

    public int NowSelectGun = 0;
    public Gun[] GunArr = new Gun[]
    {
        new Gun("AR", 30),
        new Gun("MG", 100),
        new Gun("HG", 13),
        new Gun("SG", 5)
    };

    public Joystick MoveJoystick;
    public Joystick AimJoystick;

    float PlayerRunSpeed = 1f;

    Vector3 PlayerAimPos;

    private void Start()
    {

    }

    private void Update()
    {
        PlayerMove();
        PlayerAim();
        PlayerShoot();
    }

    public void PlayerReloading()
    {
        if (GunArr[NowSelectGun].isActive == false) return;
        if (PlayerState != _PlayerState.Idle) return;

        PlayerState = _PlayerState.Reload;

        GunArr[NowSelectGun].ReloadingGun();

        PlayerState = _PlayerState.Idle;
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

    void PlayerShoot()
    {
        if (Mathf.Abs(AimJoystick.Vertical) > 0.4f || Mathf.Abs(AimJoystick.Horizontal) > 0.4f)
        {
            if (GunArr[NowSelectGun].isActive == false) return;
            GunArr[NowSelectGun].ShootingGun();
        }
    }
}

