using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Detector : MonoBehaviour
{
    public event Action PlayerEntered;
    public event Action PlayerLeft;
    
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        _collider.isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            PlayerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            PlayerLeft?.Invoke();
        }
    }
}
