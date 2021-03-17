using System;
using UnityEngine;

public class ControlUIAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private static readonly int AnimatorNoquedatiempo = Animator.StringToHash("NOQUEDATIEMPO");

    private void Awake()
    {
    }

    private void OnEnable()
    {
        PlayerPlatformInput.ControlZoneEnter += Noquedatiempo;
    }

    private void OnDisable()
    {
        PlayerPlatformInput.ControlZoneEnter -= Noquedatiempo;
    }

    private void Noquedatiempo(bool arg0)
    {
        anim.GetComponent<Animator>().SetBool(AnimatorNoquedatiempo, arg0);
    }
}