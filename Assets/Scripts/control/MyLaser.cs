using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLaser : MonoBehaviour
{
    private Vector3 _direction;
    private Vector3 _hitPoint;
    public Vector3 location;
    public LayerMask _layermask;
    private SphereCollider _collider;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject _hitBall;
    Vector3[] points = new Vector3[3];
    private bool _isBall;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }
    public void SetDirection(Vector3 dir)
    {
        
        _direction =  new Vector3(-dir.y, transform.position.y, dir.x);
        points[0] = transform.position;
    }
    public void LaserSwitch(bool status)
    {
        lr.gameObject.SetActive(status);
    }
    private void Update()
    {
        RaycastHit hits;
        
        
        if(Physics.SphereCast(transform.position, _collider.radius*2, _direction, out hits, Mathf.Infinity))
        {
            _hitPoint = hits.point+(_collider.radius*2)*hits.normal;
            _hitBall.transform.position = points[1] = new Vector3 (_hitPoint.x, transform.position.y, _hitPoint.z);

            var target = hits.collider.gameObject.transform.position;
            RaycastHit hits2;
            Debug.Log("Tag of hit object : " + hits.collider.gameObject.tag);
            if (hits.collider.gameObject.tag == "Ball")
            {
                _isBall = true;

                var heading = _hitPoint - target;
                var distance = heading.magnitude;
                var dir = heading / distance;
                dir.y = 0;
               if( Physics.Raycast(points[1], -dir, out hits2, Mathf.Infinity, _layermask))
                {
                    //Debug.Log(dir);
                    Debug.DrawRay(points[1], -dir, Color.yellow);
                    var targetForLine = points[1] + (-dir * 10);
                    points[2] = targetForLine;
                }
               
            }
            else 
            {
                _isBall = false;

                var heading = _hitPoint - transform.position;
                var distance = heading.magnitude;
                var dir = heading / distance;
                dir.y = 0;
                if (Physics.Raycast(points[0], dir, out hits2, Mathf.Infinity, _layermask))
                {
                    //Debug.Log(dir);
                    Debug.DrawRay(points[0], dir, Color.yellow);
                    var reflDir = Vector3.Reflect(dir, hits2.normal);
                    var targetForLine = points[1] + (reflDir * 10);
                    points[2] = targetForLine;
                }
               
            }
            

            lr.SetPositions(points);
        }
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = _isBall ? Color.green : Color.red;
        Gizmos.DrawSphere(new Vector3(_hitPoint.x, transform.position.y, _hitPoint.z), _collider.radius * 2.1f);
       
        
    }
#endif
}
