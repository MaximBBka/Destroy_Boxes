using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Animator LetOff;
    public Transform BoxTarget;
    [SerializeField] private Rigidbody _box;
    [SerializeField] private Transform[] arrayTakePoints;
    [SerializeField] private Transform _target;
    [SerializeField] public float moveSpeed;

    public void SetTarget(Transform target)
    {
        _target = target; 
    }
    public void SetBox(Rigidbody box)
    {
        _box = box;
        _box.isKinematic = true;
    }
    public void DownBox()
    {
        _box.transform.parent = null;
        _box.isKinematic = false;
        _box.transform.position = new Vector3(Mathf.Round(_box.transform.position.x), _box.transform.position.y, _box.transform.position.z);
        _box.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        _box = null;
    }
    private void Update()
    {
        if (_target == null) 
        {
            return;
        }
        Move();
    }
    public void Move()
    {
        float distatnce = Vector2.Distance(transform.position, _target.position);
        Vector3 positions = transform.position;
        if (distatnce > 0.01f) 
        {
            if (transform.position.x < _target.position.x)
            {
                positions.x += moveSpeed * Time.deltaTime;
                transform.position = positions;
                return;
            }else if(transform.position.x > _target.position.x)
            {
                positions.x -= moveSpeed * Time.deltaTime;
                transform.position = positions;
                return;
            }
        }
        if (_box != null)
        {
            LetOff.SetTrigger("IsDown");
            DownBox();
        }
        SetTarget(arrayTakePoints[UnityEngine.Random.Range(0,2)]);
    }
    
    
}
