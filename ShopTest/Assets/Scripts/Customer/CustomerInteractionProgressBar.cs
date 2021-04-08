using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomerInteractionProgressBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _progressBar;

    public event Action InteractionCompleted;

    private float _currentTimeForComplete = 0f;
    private float _timeToCompleteInteraction = 0f;
    bool _interactionStarted = false;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void StartInteraction(float timeForInteraction)
    {
        _timeToCompleteInteraction = timeForInteraction;
        _canvas.enabled = true;
        _interactionStarted = true;
    }

    private void Update()
    {
        if (!_interactionStarted)
            return;

        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);

        _currentTimeForComplete += Time.deltaTime;
        _progressBar.value = _currentTimeForComplete / _timeToCompleteInteraction;

        if (_currentTimeForComplete >= _timeToCompleteInteraction)
        {
            _progressBar.value = 0;
            _canvas.enabled = false;
           _currentTimeForComplete = 0f;
            _interactionStarted = false;
            InteractionCompleted?.Invoke();
        }
    }
}
