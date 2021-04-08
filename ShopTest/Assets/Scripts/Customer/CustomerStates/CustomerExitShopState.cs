using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerExitShopState : CustomerState
{
    [SerializeField] private CustomerMover _mover;

    public override void Begin()
    {
        base.Begin();
        _mover.MoveToPoint(_stateContext.ShopExitPoint);
        _mover.DestinationReached += Exit;
    }

    public override void Exit()
    {
        _mover.StopMoving();
        _stateContext.EventsRelay.DispatchCustomerLeftStore(_stateContext.CurrentCustomer);
        _mover.DestinationReached -= Exit;
        base.Exit();
    }
}
