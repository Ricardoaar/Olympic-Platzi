﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GhostBehavior : DieOnAnimationFinishComponent
{
    public enum GhostType
    {
        Dark = 1,
        White = 2
    }

    private GameObject _player;

    [SerializeField] private Animator ghostAnimator;
    [SerializeField] private SpriteRenderer ownSprite;
    [SerializeField] private Collider2D ghostCollider;
    private static readonly int AnimatorIsAlive = Animator.StringToHash("isAlive");
    public GhostSpawnSystem ghostSpawnSystem;


    private GhostType _ghostType;
    public GhostType GetGhostType => _ghostType;

    [SerializeField] private float velocity, minWaitTime, maxWaitTime;
    private float _initialVelocity;

    private void Awake()
    {
        if (_player == null)
        {
            _player = GameObject.Find("Player");
        }

        _initialVelocity = velocity;
        ghostSpawnSystem = transform.GetComponentInParent<GhostSpawnSystem>();
    }


    private void ChangeRotation(Vector3 lookAt)
    {
        var rotateY = transform.position.x > lookAt.x;

        float yRotation = rotateY ? 0 : 180;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation,
            Util.GetAngleFromTwoVectors(transform.position, rotateY ? -lookAt : lookAt));
    }

    [SerializeField] private Vector2 offsetPlayer;


    private IEnumerator PrepareAttack()
    {
        var waitTime = Random.Range(minWaitTime, maxWaitTime);
        float currentTime = 0;
        while (currentTime < waitTime)
        {
            ChangeRotation(_player.transform.position);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(DoAttack());
    }


    private IEnumerator DoAttack()
    {
        var goRight = _player.transform.position.x > transform.position.x;

        Vector3 offset = goRight ? (Vector3) offsetPlayer : new Vector3(-offsetPlayer.x, offsetPlayer.y);

        transform.SetParent(null);
        var currentCount = 0.0f;
        //State 1
        while (Math.Abs(transform.position.x - _player.transform.position.x) > 0.1f &&
               Math.Abs(transform.position.y - _player.transform.position.y) > 0.05f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                    _player.transform.position + offset,
                    velocity * Time.deltaTime);


            ChangeRotation(_player.transform.position);


            if (currentCount > 1.0f)
            {
                velocity += 1;
                currentCount = 0;
            }
            else
                currentCount += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(SimulateMove(goRight));
    }

    private IEnumerator SimulateMove(bool goRight)
    {
        var currentCount = 0.0;
        while (currentCount < 1.0f)
        {
            transform.position += new Vector3(goRight ? velocity * Time.deltaTime : -velocity * Time.deltaTime,
                -1.0f * Time.deltaTime);
            currentCount += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(GoToOtherSide(goRight));
    }

    private IEnumerator GoToOtherSide(bool goRight)
    {
        var newPos = GhostSpawnSystem.Instance.GetRandomPos(goRight);
        while (Math.Abs(transform.position.x - newPos.x) > 0.2f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, newPos, velocity * Time.deltaTime);

            ChangeRotation(newPos);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }

    private IEnumerator DieCoroutine()
    {
        ghostAnimator.SetBool(AnimatorIsAlive, false);
        while (!canDead)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                    new Vector3(
                        GhostSpawnSystem.Instance.GetRandomPos(_player.transform.position.x > transform.position.x).x,
                        -10)
                    ,
                    velocity * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
    }

    public void Die()
    {
        ghostCollider.enabled = false;
        StopAllCoroutines();
        StartCoroutine(DieCoroutine());
    }

    private void OnEnable()
    {
        SetValues();
        StopAllCoroutines();
        StartCoroutine(PrepareAttack());
        PlatPlayerInteractive.OnDamage += DisableGhost;
        PlatPlayerInteractive.OnStoneEnter += DisableGhost;
    }

    private void DisableGhost()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PlatPlayerInteractive.OnDamage -= DisableGhost;
        PlatPlayerInteractive.OnStoneEnter -= DisableGhost;

        ghostSpawnSystem.OnGhostDisable(gameObject);
    }


    private void SetValues()
    {
        ghostCollider.enabled = true;
        ghostAnimator.SetBool(AnimatorIsAlive, true);
        canDead = false;
        _ghostType = Random.Range(0, 1.0f) > 0.5f ? GhostType.Dark : GhostType.White;
        ownSprite.color = _ghostType == GhostType.Dark ? Color.black : Color.white;
        velocity = _initialVelocity;
    }
}


public abstract class DieOnAnimationFinishComponent : MonoBehaviour
{
    [HideInInspector] public bool canDead;
}