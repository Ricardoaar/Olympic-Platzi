using System;
using UnityEngine;

public class NOQUEDATIEMPO : MonoBehaviour
{
    [SerializeField] private GameObject anim;
    private static readonly int AnimatorNoquedatiempo = Animator.StringToHash("NOQUEDATIEMPO");

    private void Awake()
    {
    }

    private void OnEnable()
    {
        PlayerPlatformInput.NOQUEDATIEMPO += Noquedatiempo;
    }

    private void OnDisable()
    {
        PlayerPlatformInput.NOQUEDATIEMPO -= Noquedatiempo;
    }

    private void Noquedatiempo(bool arg0)
    {
        anim.GetComponent<Animator>().SetBool(AnimatorNoquedatiempo, arg0);
    }
}