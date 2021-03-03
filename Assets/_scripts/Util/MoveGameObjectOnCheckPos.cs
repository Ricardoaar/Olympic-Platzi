using UnityEngine;

public class MoveGameObjectOnCheckPos : MonoBehaviour
{
    private DifferencePositionChecker _differencePositionChecker;
    [SerializeField] private float movement;
    private float _initialY;

    private void Awake()
    {
        _differencePositionChecker = GetComponent<DifferencePositionChecker>();
        _initialY = transform.position.y;
    }

    private void OnEnable()
    {
        PlayerPlatformInput.OnPlayerMove += OnPlayerMove;
    }

    private void OnDisable()
    {
        PlayerPlatformInput.OnPlayerMove -= OnPlayerMove;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _initialY, _initialY));
    }

    private void OnPlayerMove(Vector2 vector)
    {
        if (_differencePositionChecker.Check())
        {
            Move(vector.x);
        }
    }

    private void Move(float vectorX)
    {
        transform.Translate(-new Vector3(vectorX * movement, 0, 0) * Time.deltaTime);
    }
}