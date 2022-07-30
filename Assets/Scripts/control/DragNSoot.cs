using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNSoot : MonoBehaviour
{
   
    public float power = 10;
    public Rigidbody rb;
    public Trajectory _tline;
    public Vector3 minPower;
    public Vector3 maxPower;
    public Camera cam;
    Vector3 force;
    Vector3 startPoint;
    Vector3 endPoint;

   
    private void Update()
    {
        if (!MainBall.M._stoped) return;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Transform objectHit = hit.transform;
                startPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                startPoint.y = 15;
                //Debug.Log($"Click start pos: {startPoint}");
            }
           
            
            if (Input.GetMouseButtonUp(0))
            {
                endPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                //endPoint.z = 15;

                force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), 0, Mathf.Clamp(startPoint.z - endPoint.z, minPower.z, maxPower.z));
                rb.AddForce(force * power, ForceMode.Impulse);
                //Debug.Log($"Click end pos: {endPoint}");
            }
        }
            
        
    }
}
