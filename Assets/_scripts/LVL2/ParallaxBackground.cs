using UnityEngine;

[DisallowMultipleComponent]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float initialBackgroundVelocity;

    [SerializeField, Tooltip("Entre mas grande mas lento crece"), Range(0.1f, 20)]
    private float delayGrowSpeed;

    private float _sizeX;
    [SerializeField] private BoxCollider2D backgroundSprite;
    private Vector3 _initialPosition;
    private float _currentBackgroundVelocity;
    [SerializeField] private float _velLimit;

    private void Awake()
    {
        _currentBackgroundVelocity = initialBackgroundVelocity;
        _sizeX = backgroundSprite ? backgroundSprite.size.x : Mathf.Infinity;
        _initialPosition = transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO condicional que detenga el juego
        transform.Translate(-_currentBackgroundVelocity * Time.deltaTime, 0, 0);
        if(_currentBackgroundVelocity < _velLimit)
        {
            _currentBackgroundVelocity += Time.deltaTime / delayGrowSpeed;
        }
        transform.position = -transform.position.x > _initialPosition.x + _sizeX ? _initialPosition : transform.position;
        //Debug.Log(_sizeX, gameObject);
    }
}