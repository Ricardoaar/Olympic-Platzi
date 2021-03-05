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

    [SerializeField] private GlobalFloat _gameVelocity;

    private bool _initGame = false;

    private void Awake()
    {
        _currentBackgroundVelocity = initialBackgroundVelocity;
        _sizeX = backgroundSprite ? backgroundSprite.size.x : Mathf.Infinity;
        _initialPosition = transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_initGame)
        {
            return;
        }
        transform.Translate(-_currentBackgroundVelocity * Time.deltaTime * _gameVelocity.vFloat, 0, 0);
        if(_currentBackgroundVelocity < _velLimit)
        {
            _currentBackgroundVelocity += Time.deltaTime / delayGrowSpeed;
        }
        transform.position = -transform.position.x > _initialPosition.x + _sizeX ? _initialPosition : transform.position;
        //Debug.Log(_sizeX, gameObject);
    }

    public void SetInitGame()
    {
        _initGame = !_initGame;
    }
}