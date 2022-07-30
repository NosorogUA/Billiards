using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : MonoBehaviour
{
    protected Vector3 _direction;
    protected Vector3 Startpos;
    protected bool ResetIt;
    public bool _stoped;
    protected Rigidbody _rb;


    // Use this for initialization
    protected virtual void Start()
    {
        Startpos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void LateUpdate()
    {

        if (_rb.velocity.x <= 1 && _rb.velocity.x >= -1)
        {
            if (_rb.velocity.z <= 1 && _rb.velocity.z >= -1)
            {
                StopBall();
            }
            else
            {
                _stoped = false;
        }
        }
        else
        {
            _stoped = false;
        }

    }

    private void StopBall()
    {
        _rb.velocity = Vector3.zero;
        _stoped = true;
    }
    [ContextMenu("Reset")]
    public void ResetBall()
    {
        gameObject.SetActive(true);
        transform.position = Startpos;
        _rb.velocity = Vector3.zero;
    }
}