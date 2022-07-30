using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLevelComponent : MonoBehaviour
{
    private NormalBall[] _activeBalls;
    [SerializeField] private float _count;
    public static ReloadLevelComponent RL;
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        RL = this;
    }

    private void OnStart()
    {
        _activeBalls = FindObjectsOfType<NormalBall>();
        _count = _activeBalls.Length-1;
        checkCount();
    }
    public void DisableBall()
    {
        _count -= 1;
        checkCount();
    }
    /*public void StartBalls()
    {
        foreach (var ball in _activeBalls)
        {
            ball._stoped = false;
        }
    }*/

    private void checkCount()
    {
        Debug.Log($"Ball count - {_count}");

        if(_count <= 0)
        {
            Debug.Log($"reset balls");
            foreach (var ball in _activeBalls)
            {
                ball.ResetBall();
            }
        }
    }
}
