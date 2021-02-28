using System.Collections;
using UnityEngine;

public class BoxPlacer : MonoBehaviour
{
    [SerializeField] private Collider2D trigger;
    private Coroutine _cPlace;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float gradesPerSecondRotation, unitsPerSecondMovement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != trigger || _cPlace != null) return;
        _cPlace = StartCoroutine(PlaceBox());
    }

    private IEnumerator PlaceBox()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;

        var difTransform = transform.rotation.eulerAngles.z % 90 < 45;


        while (transform.position != trigger.gameObject.transform.position ||
               transform.rotation.eulerAngles.z % 90 > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, trigger.gameObject.transform.position,
                unitsPerSecondMovement * Time.deltaTime);
            if (transform.rotation.eulerAngles.z % 90 > 2f)
            {
                transform.Rotate(Vector3.forward *
                                 (Time.deltaTime * gradesPerSecondRotation * (difTransform ? -1 : 1)));
            }

            yield return new WaitForEndOfFrame();
        }
    }
}