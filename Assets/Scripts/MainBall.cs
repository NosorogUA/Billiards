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
        _joystik.SetActive(_stoped);
    }
   

}
