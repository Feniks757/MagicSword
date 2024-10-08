using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Portal : MonoBehaviour
{
    [SerializeField] private int _soulsAmountForActivation;
    [SerializeField] private PortalActivator _portalActivator;
    [SerializeField] private LoadSceneByIndex _loadSceneByIndex;

    private Animator _animator;
    private int _currentSoulsAmountForActivation;
    private bool _isActive;

    public Action SoulsCollected;
    public Action<int> SoulsChanged;

    public int SoulsAmountForActivation => _soulsAmountForActivation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _portalActivator.PortalActivatorActivated += OnPortalActivatorActivated;
    }

    private void OnDisable()
    {
        _portalActivator.PortalActivatorActivated -= OnPortalActivatorActivated;
    }

    private void OnPortalActivatorActivated()
    {
        _animator.SetTrigger("Activation");
        _isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Soul soul))
        {
            _currentSoulsAmountForActivation++;
            SoulsChanged?.Invoke(_currentSoulsAmountForActivation);

            if (_currentSoulsAmountForActivation == _soulsAmountForActivation)
            {
                SoulsCollected?.Invoke();
            }
        }

        if (collision.gameObject.GetComponentInChildren<Player>() != null && _isActive)
        {
            StartCoroutine(_loadSceneByIndex.LoadScene());
        }
    }
}
