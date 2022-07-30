using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    protected LineRenderer lr;
    Vector3[] points = new Vector3[2];
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 endpoint)
    {
        points[0] = transform.position;
        points[1] = transform.position - new Vector3(-endpoint.y, 0, endpoint.x);

        lr.SetPositions(points);
        TrajectorySwitch(true);
    }
   
    public void HideLine()
    {
        points[0] = transform.position;
        points[1] = transform.position;

        lr.SetPositions(points);
        TrajectorySwitch(false);
    }

    public void TrajectorySwitch(bool status)
    {
        lr.enabled = status;
    }
}
