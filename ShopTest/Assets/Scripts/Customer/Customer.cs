using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private CustomerStateMachine _stateMachine = null;

    public void SetContext(CustomerStateContext context)
    {
        context.CurrentCustomer = this;
        _stateMachine.SetContext(context);
    }
}
