using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersController : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private CustomersFactory _factory = null;
    [SerializeField] private CustomersEventsReley _eventsReley = null;
    [SerializeField] private InteractablesHolder _interactablesHolder = null;

    [Header("Transforms")]
    [SerializeField] private Transform _customerSpawnPoint;
    [SerializeField] private Transform _shopEnter;
    [SerializeField] private Transform _shopExit;


    float timeBetweenCustomers = 5f;
    float currentTime = 0f;

    private void SpawnNewCustomerAndSetIfForInteraction()
    {
        var nonBusyInteractionPoint = _interactablesHolder.GetNonBusyInteractableObject();

        if (nonBusyInteractionPoint is null)
            return;

        nonBusyInteractionPoint.IsBusy = true;

        var newCustomer = _factory.SpawnNewCustomer(_customerSpawnPoint.position);

        CustomerStateContext stateContext = new CustomerStateContext();

        stateContext.CustomerInteractPoint = nonBusyInteractionPoint;
        stateContext.EventsRelay = _eventsReley;
        stateContext.ShopEnterPoint = _shopEnter.position;
        stateContext.ShopExitPoint = _shopExit.position;

        newCustomer.SetContext(stateContext);

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timeBetweenCustomers)
        {
            SpawnNewCustomerAndSetIfForInteraction();
            currentTime = 0;
        }
    }
}
