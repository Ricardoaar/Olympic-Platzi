using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class OnSoundTriggerEnter : UnityEvent
{
}

public class SoundTrigger : MonoBehaviour
{
    public OnSoundTriggerEnter onSoundTriggerEnter;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Epic Sound");
            onSoundTriggerEnter.Invoke();
        }
    }
}