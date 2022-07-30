using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandOn : MonoBehaviour
{
    [SerializeField] Transform _ball;
    public Plane plane
    {
        private set;
        get;
    }
    private void Update()
    {
        plane = new Plane(_ball.up, _ball.position);
        transform.position = _ball.position;
        transform.up = _ball.up;
    }
}
