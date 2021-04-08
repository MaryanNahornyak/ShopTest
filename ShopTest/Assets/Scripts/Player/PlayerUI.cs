using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController = null;
    [SerializeField] private TextMeshProUGUI _coinsText = null;

    private void Awake()
    {
        _playerController.AmountOfCoinsChanged += OnPlayerCoinsAmountChanged;
    }

    private void OnPlayerCoinsAmountChanged(int obj)
    {
        _coinsText.text = obj.ToString();
    }
}
