using UnityEngine;

public class PositionDifferenceChecker : MonoBehaviour
{
    private float _xDiff, _initialX;
    [SerializeField] private Transform target;

    public float GetDifference()
    {
        return _initialX - target.transform.position.x;
    }

    private void Awake()
    {
        _initialX = target.position.x;
    }
}