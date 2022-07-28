using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private GameObject _mainBall;
    [SerializeField]/*[Range(0,50)]*/ private float _forse;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction =  Vector3.zero;
        if(Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            var ballpos = new Vector3(_mainBall.transform.position.x, _mainBall.transform.position.y, _mainBall.transform.position.z);
            var mousepos = new Vector3(hit.point.x, _mainBall.transform.position.y, hit.point.z);
            _line.SetPosition(0, ballpos);
            _line.SetPosition(1, mousepos);
            direction = (mousepos - ballpos).normalized;
        }    
        if(Input.GetMouseButtonDown(0))
        {
            _mainBall.GetComponent<Rigidbody>().velocity = direction * _forse;
        }
    }
}
