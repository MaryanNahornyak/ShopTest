using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] int _rewardValue = 5;
    [SerializeField] float _timeToComplete = 1f;

    public bool IsBusy { get; set; }

    public float GetTimeToComplete() { return _timeToComplete; }
    public  int GetRewardValue() { return _rewardValue; }
    public Vector3 GetPosition() { return transform.position; }
}
