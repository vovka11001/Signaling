using System;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action OnPlayerInside;
    public event Action OnPlayerOutside;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            OnPlayerInside?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rigidbody))
        {
            OnPlayerOutside?.Invoke();
        }
    }
}
