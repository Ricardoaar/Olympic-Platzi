using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDCheckPoint : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<TDPlayerController>().SetCheckPoint(transform.position);
            _collider.enabled = false;
        }
    }
}
