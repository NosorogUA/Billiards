using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLaser : MonoBehaviour
{
    private Vector3 _direction;
    private Vector3 _hitPoint;
    public Vector3 location;
    private SphereCollider _collider;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject _hitBall;
    Vector3[] points = new Vector3[3];
    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }
    public void SetDirection(Vector3 dir)
    {
        
        _direction =  new Vector3(-dir.y*2, transform.position.y, dir.x*2);
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
            Debug.DrawRay(transform.position, _direction, Color.yellow);

            _hitPoint = hits.point+(_collider.radius*2)*hits.normal;
            _hitBall.transform.position = points[1] = _hitPoint;
            
            if(hits.collider.gameObject.tag == "Ball")
            {
                var target = hits.collider.gameObject.transform.position;
                Debug.DrawRay(points[1], target, Color.green);
                points[2] =  target;
            }
            else
            {
                points[2] = points[1];
            }

            lr.SetPositions(points);
        }
       
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //Gizmos.color = _isGrounded ? Color.green : Color.red;
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_hitPoint, _collider.radius*2);
    }
#endif
}
