using JetBrains.Annotations;
using UnityEngine;

public class RayLayerChecker : MonoBehaviour
{
    [SerializeField] private LayerMask layerToCheck;
    [SerializeField, Range(0.01f, 5)] private float distance;
    [SerializeField, CanBeNull] private BoxCollider2D limits;
    private Vector3 _min, _max;
    private bool _multiCheckGround;

    private void Awake()
    {
        limits = limits == null ? GetComponent<BoxCollider2D>() : limits;
    }

    //Uncomment to debug rays
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawRay(_min, Vector3.down);
    //     Gizmos.DrawRay(_max, Vector3.down);
    //
    //     Gizmos.DrawRay(transform.position, Vector3.down);
    // }

    public bool CheckRayToLayer()
    {
        if (limits is null) return CheckPointOnGround(transform.position);

        _min = limits.bounds.min;
        _max = new Vector3(limits.bounds.max.x, _min.y);

        return CheckPointOnGround(new Vector3(transform.position.x, _min.y)) || CheckPointOnGround(_min) ||
               CheckPointOnGround(_max);
    }

    public RaycastHit2D GetRay(float lDistance = 0) => Physics2D.Raycast(new Vector3(transform.position.x, _min.y),
        Vector2.down,
        lDistance > 0 ? lDistance : distance, layerToCheck);

    public RaycastHit2D GetRay() => Physics2D.Raycast(new Vector3(transform.position.x, _min.y),
        Vector2.down, 50, layerToCheck);


    /// <summary>
    /// Check if a specific position is on touching the layer
    /// </summary>
    /// <param name="position">position to check</param>
    /// <returns>Value of raycast from position to layer</returns>
    private bool CheckPointOnGround(Vector3 position) => Physics2D.Raycast(position,
        Vector2.down,
        distance, layerToCheck);
}