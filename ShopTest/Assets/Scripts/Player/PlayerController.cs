using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string prevSavedGameFileName = "savedCoins";

    public int CurrentAmountOfCoints
    {
        get => _currentAmountOfCoins;
        set
        {
            _currentAmountOfCoins += value;
            AmountOfCoinsChanged?.Invoke(_currentAmountOfCoins);
        }
    }

    public event Action<int> AmountOfCoinsChanged;
    private int _currentAmountOfCoins = 0;

    private void Start()
    {
        LoadPrevSession();
        CustomersEventsReley.CustomerFinishedInteraction += OnCustomerFinisedInteracting;
    }

    private void LoadPrevSession()
    {
        var path = Path.Combine(Application.persistentDataPath, prevSavedGameFileName + ".txt");

        if (!File.Exists(path))
        {
            File.Create(path);
            return;
        }

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                var text = reader.ReadToEnd();

                CurrentAmountOfCoints = Convert.ToInt32(text);
            }
        }


    }

    private void SaveCurSession()
    {
        var path = Path.Combine(Application.persistentDataPath, prevSavedGameFileName + ".txt");

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(CurrentAmountOfCoints.ToString());
            }
        }
    }

    private void OnDestroy()
    {
        SaveCurSession();
    }

    private void OnCustomerFinisedInteracting(Interactable obj)
    {
        int interactionObjectValue = obj.GetRewardValue();

        CurrentAmountOfCoints = interactionObjectValue;
    }
}
