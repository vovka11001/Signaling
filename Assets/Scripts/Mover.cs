using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private CheckPoint[] _checkPoints;
    
    private float _speed = 2f;
    private int _currentTargetIndex = 0;
    private float _offset;

    private void Start()
    {
        _offset = 0.01f * 0.01f;
    }
    
    private void Update()
    {
        if (_checkPoints.Length == 0) 
            return;
    
        Transform target = _checkPoints[_currentTargetIndex].transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        Vector3 offset = transform.position - target.position;
        
        if (offset.sqrMagnitude <= _offset)
        {
            _currentTargetIndex = (_currentTargetIndex + 1) % _checkPoints.Length; 
        }
    }
}
