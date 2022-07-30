using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private float _usedOffDelay = 0.5f;
    [SerializeField] private bool _isUsed;
    [SerializeField] private bool _ignorUsed;
  
    [SerializeField] private EnterEvent _actionEnter;
    
    private void Awake()
    {
        _isUsed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag + other.gameObject.name);

        if (other.gameObject.CompareTag(_tag))
        {
            if(!_ignorUsed)
            {
                if (_isUsed) return;
            }

            _actionEnter?.Invoke(other.gameObject);

            _isUsed = true;
        }
       
    }
    
    public void ResetUsed()
    {
        StartCoroutine(UsedOff());
    }

    private IEnumerator UsedOff()
    {
        
        yield return new WaitForSeconds(_usedOffDelay);
        _isUsed = false;
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {

    }

}
