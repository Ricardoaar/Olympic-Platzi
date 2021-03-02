using UnityEngine;

public class TDControlInverter : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<TDPlayerController>().SwitchInputs();
            _collider.enabled = false;
        }
    }
}
