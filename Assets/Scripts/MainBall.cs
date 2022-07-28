using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBall : MonoBehaviour
{
    protected Vector3 Startpos;
    protected bool ResetIt;
   
    void Start()
    {
        Startpos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -0.1f)
        {
            transform.position = new Vector3(0, 0.08f, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (ResetIt)
        {
            ResetIt = false;
            transform.position = Startpos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void ResetBall()
    {
        ResetIt = true;
    }
}
