using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEnterShopState : CustomerState
{
    [SerializeField] private CustomerMover _mover;

    public override void Begin()
    {
        base.Begin();
        _mover.MoveToPoint(_stateContext.ShopEnterPoint);
        _mover.DestinationReached += Exit;
    }

    public override void Exit()
    {
        base.Exit();
        _mover.DestinationReached -= Exit;
        _stateContext.StateMachine.GoToInteractPoint();
    }

}
