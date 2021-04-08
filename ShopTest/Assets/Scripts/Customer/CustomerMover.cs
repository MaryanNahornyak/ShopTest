using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private Animator _customerAnimator;


    private void Start()
    {
        _agent.speed = _moveSpeed;
    }

    public Action DestinationReached;

    bool isMoving = false;
    public void MoveToPoint(Vector3 point)
    {
        _agent.destination = point;
        _customerAnimator.SetBool("Walk", true);
        isMoving = true;
    }

    public void StopMoving()
    {
        //_agent.isStopped = true;
        DestinationReached = null;
        _customerAnimator.SetBool("Walk", false);
    }

    private void Update()
    {
        if (_agent.pathPending)
            return;

        if(_agent.remainingDistance <= 0.1f && isMoving)
        {
            isMoving = false;
            DestinationReached?.Invoke();           
        }
    }
}
