using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMoveToInteractPointState : CustomerState
{
    [SerializeField] private CustomerMover _mover;

    public override void Begin()
    {
        var interactPointPosition = _stateContext.CustomerInteractPoint.GetPosition();
        _mover.MoveToPoint(interactPointPosition);
        _mover.DestinationReached += Exit;
    }

    public override void Exit()
    {
        _mover.StopMoving();
        _mover.DestinationReached -= Exit;
        _stateContext.StateMachine.InteractWithPoint();
    }
}
