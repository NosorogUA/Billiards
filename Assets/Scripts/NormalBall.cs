using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : MonoBehaviour
{
    private Vector3 _direction;
    protected Vector3 Startpos;
    protected bool ResetIt;

    // Use this for initialization
    void Start()
    {
        Startpos = transform.position;
    }
       
    public void ResetBall()
    {
        transform.position = Startpos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}