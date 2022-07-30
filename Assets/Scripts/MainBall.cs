using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBall : NormalBall
{
    [SerializeField] private GameObject _joystik;
    public static MainBall M;

    protected override void Start()
    {
        base.Start();
        M = this;
    }
    protected override void LateUpdate()
    {
        base.LateUpdate();
        SwitchControl(_stoped);
    }
    private void SwitchControl(bool status)
    {
        _joystik.SetActive(status);
        _joystik.GetComponent<JoysticAreaComponent>().enabled = status;
    }

}
