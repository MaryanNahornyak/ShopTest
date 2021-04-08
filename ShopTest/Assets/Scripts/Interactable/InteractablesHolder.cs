using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesHolder : MonoBehaviour
{
    [SerializeField] private List<Interactable> _sceneInteractableObjects = null;

    public Interactable GetNonBusyInteractableObject()
    {
        var nonBusy = _sceneInteractableObjects.Find(i => !i.IsBusy);

        return nonBusy;
    }
}
