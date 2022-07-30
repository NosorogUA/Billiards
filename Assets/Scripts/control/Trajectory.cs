using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    protected LineRenderer lr;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 endpoint)
    {
       
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position - new Vector3(-endpoint.y, 0, endpoint.x);

        lr.SetPositions(points);
    }
    public void HideLine()
    {
        
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position;

        lr.SetPositions(points);
    }
    public void TrajectorySwitch(bool status)
    {
        lr.enabled = status;
    }
}
