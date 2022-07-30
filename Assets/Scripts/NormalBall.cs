using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : MonoBehaviour
{
    protected Vector3 _direction;
    protected Vector3 Startpos;
    protected bool ResetIt;

    // Use this for initialization
    protected virtual void Start()
    {
        Startpos = transform.position;
    }
    public void  StpoVel()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    [ContextMenu("Reset")]
    public void ResetBall()
    {
        gameObject.SetActive(true);
        transform.position = Startpos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}