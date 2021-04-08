using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomerEnterShopState))]
[RequireComponent(typeof(CustomerExitShopState))]
[RequireComponent(typeof(CustomerInteractionState))]
[RequireComponent(typeof(CustomerMoveToInteractPointState))]
public class CustomerStateMachine : MonoBehaviour
{
    private CustomerState _enterShopState;
    private CustomerState _interactState;
    private CustomerState _goToInteractState;
    private CustomerState _exitShopState;

    private CustomerState _currentState;

    private CustomerStateContext _stateContext;

    private void Awake()
    {
        _enterShopState = GetComponent<CustomerEnterShopState>();
        _exitShopState = GetComponent<CustomerExitShopState>();
        _interactState = GetComponent<CustomerInteractionState>();
        _goToInteractState = GetComponent<CustomerMoveToInteractPointState>();

       
    }

    public void SetContext(CustomerStateContext context)
    {
        _stateContext = context;
        _stateContext.StateMachine = this;

        _enterShopState.SetContext(_stateContext);
        _interactState.SetContext(_stateContext);
        _goToInteractState.SetContext(_stateContext);
        _exitShopState.SetContext(_stateContext);

        ChangeState(_enterShopState);
    }

    public void GoToInteractPoint()
    {
        ChangeState(_goToInteractState);
    }

    public void InteractWithPoint()
    {
        ChangeState(_interactState);
    }

    public void EnterShop()
    {
        ChangeState(_enterShopState);
    }

    public void ExitShop()
    {
        ChangeState(_exitShopState);
    }

    private void ChangeState(CustomerState newState)
    {
        _currentState = newState;
        newState.Begin();
    }
}
