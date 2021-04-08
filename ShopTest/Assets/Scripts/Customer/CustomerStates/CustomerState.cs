using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerState : MonoBehaviour
{
    protected CustomerStateContext _stateContext;

    public void SetContext(CustomerStateContext context)
    {
        _stateContext = context;
    }

    public virtual void Begin() { }
    public virtual void Exit() { }
}

public class CustomerStateContext
{
    public Vector3 ShopEnterPoint;
    public Vector3 ShopExitPoint;
    public Customer CurrentCustomer;
    public Interactable CustomerInteractPoint;
    public CustomerStateMachine StateMachine;
    public CustomersEventsReley EventsRelay;
}
