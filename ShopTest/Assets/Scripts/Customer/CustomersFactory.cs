using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomersFactory : MonoBehaviour
{
    public Customer _simpleCustomerPrefab;

    private List<Customer> _inactiveCustomers;

    private void Start()
    {
        _inactiveCustomers = new List<Customer>();
        CustomersEventsReley.CustomerLeftShop += OnCustomerLeftShop;
    }

    private void OnCustomerLeftShop(Customer obj)
    {
        obj.gameObject.SetActive(false);
        _inactiveCustomers.Add(obj);
    }

    public Customer SpawnNewCustomer(Vector3 position)
    {
        var customer = GetInactiveCustomer(position);

        if(customer is null)
        {
            customer = Instantiate(_simpleCustomerPrefab, position, Quaternion.identity);
        }

        return customer;
    }

    private Customer GetInactiveCustomer(Vector3 spawnPosition)
    {
        Customer inactiveCustomer = null;

        if (_inactiveCustomers.Count > 0)
        {
            inactiveCustomer = _inactiveCustomers[0];
            inactiveCustomer.gameObject.transform.position = spawnPosition;
            inactiveCustomer.gameObject.SetActive(true);
            _inactiveCustomers.Remove(inactiveCustomer);
        }
        
        return inactiveCustomer;
    }
}
