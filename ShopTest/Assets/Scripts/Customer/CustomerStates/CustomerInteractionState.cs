using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteractionState : CustomerState
{
    [SerializeField] private CustomerInteractionProgressBar _progressBar;

    private void Start()
    {
        _progressBar.InteractionCompleted += Exit;
    }

    private void OnDestroy()
    {
        _progressBar.InteractionCompleted -= Exit;
    }

    public override void Begin()
    {
        _progressBar.StartInteraction(_stateContext.CustomerInteractPoint.GetTimeToComplete());
    }

    public override void Exit()
    {
        _stateContext.CustomerInteractPoint.IsBusy  = false;
        _stateContext.EventsRelay.DispatchCustomerFinishedInteraction(_stateContext.CustomerInteractPoint);
        _stateContext.StateMachine.ExitShop();
    }


}
