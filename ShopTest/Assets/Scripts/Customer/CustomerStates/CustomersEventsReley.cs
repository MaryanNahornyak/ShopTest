using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersEventsReley : MonoBehaviour
{
    public static event Action<Interactable> CustomerFinishedInteraction;
    public static event Action<Customer> CustomerLeftShop;

    public void DispatchCustomerFinishedInteraction(Interactable interactable)
    {
        CustomerFinishedInteraction?.Invoke(interactable);
    }

    public void DispatchCustomerLeftStore(Customer customer)
    {
        CustomerLeftShop?.Invoke(customer);
    }
}
