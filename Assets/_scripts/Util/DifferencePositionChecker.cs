using UnityEngine;

public class DifferencePositionChecker : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float difference;
    private float _currentMax;

    private void Start()
    {
        _currentMax = target.position.x;
    }

    public bool Check()
    {
        if (Mathf.Abs(_currentMax - target.position.x) <= difference) return false;

        _currentMax = target.transform.position.x;
        return true;
    }
}