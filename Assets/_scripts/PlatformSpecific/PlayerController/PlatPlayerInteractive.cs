using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlatPlayerInteractive : MonoBehaviour
{
    public static UnityAction OnDamage;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject root;
    [SerializeField] private SpriteResolver headChanger;
    [SerializeField] private RayLayerChecker checker;
    [SerializeField] private ParticleSystem onDieParticles;
    [SerializeField] private Color dieParticleColor;
    private static readonly int AnimatorVMovementX = Animator.StringToHash("MoveX");
    private static readonly int AnimatorVMovementY = Animator.StringToHash("MoveY");
    private static readonly int AnimatorMoving = Animator.StringToHash("Moving");
    private static readonly int AnimatorJumpTrig = Animator.StringToHash("Jump");
    private static readonly int AnimatorGroundCheck = Animator.StringToHash("IsOnGround");
    private static readonly int AnimatorGroundDistance = Animator.StringToHash("DistanceToGround");
    private static readonly int AnimatorLastX = Animator.StringToHash("LastX");
    private static readonly int AnimatorDash = Animator.StringToHash("Dash");

    private readonly List<GameObject> _rootChild = new List<GameObject>();

    private void CollisionWithEnemy()
    {
        var mainParticleModule = onDieParticles.main;
        mainParticleModule.startColor = root.transform.eulerAngles.y == 0 ? dieParticleColor : Color.black;
        var partSys = Instantiate(onDieParticles, transform.position, Quaternion.identity);
        OnDamage.Invoke();
        ChangePlayerComponents(false);
        Destroy(partSys, 3);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinalScene"))
        {
            GameManagePlatform.OnWinScene.Invoke();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("TextStone"))
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            OnStoneEnter.Invoke();
        }

        if (other.gameObject.layer != LayerMask.NameToLayer("DamagePlayer")) return;
        var killEnemy = false;
        if (other.transform.parent.TryGetComponent(typeof(GhostBehavior), out var dummy))
        {
            CollisionWithGhost(other, out killEnemy);
        }

        if (!killEnemy)
        {
            CollisionWithEnemy();
        }
    }

    public static Action OnStoneEnter;

    public static Action OnKillEnemy;


    private void CollisionWithGhost(Collider2D ghost, out bool killEnemy)
    {
        var ghostType = ghost.transform.parent.GetComponent<GhostBehavior>();
        killEnemy = false;
        switch (ghostType.GetGhostType)
        {
            case GhostBehavior.GhostType.Dark when Math.Abs(root.transform.eulerAngles.y - 180) < 0.5f:
                ghostType.Die();
                killEnemy = true;
                OnKillEnemy.Invoke();

                return;
            case GhostBehavior.GhostType.White when root.transform.rotation == Quaternion.identity:
                ghostType.Die();
                killEnemy = true;
                OnKillEnemy.Invoke();
                return;
        }
    }


    private void ChangePlayerComponents(bool active)
    {
        foreach (var child in _rootChild)
        {
            child.SetActive(active);
        }
    }

    private void Start()
    {
        for (var i = 0; i < root.transform.childCount; i++)
        {
            if (!root.transform.GetChild(i).TryGetComponent(typeof(Light2D), out var dummy))
            {
                _rootChild.Add(root.transform.GetChild(i).gameObject);
            }
        }
    }

    private void SetGroundStatus()
    {
        var onGround = checker.CheckRayToLayer();
        animator.SetBool(AnimatorGroundCheck, onGround);
        animator.SetFloat(AnimatorGroundDistance, checker.GetRay().distance);
    }

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (headChanger == null)
        {
            headChanger = GameObject.Find("HeadResolver").GetComponent<SpriteResolver>();
        }

        if (checker == null)
        {
            checker = GetComponent<RayLayerChecker>();
        }
    }

    private void Update()
    {
        SetGroundStatus();
    }

    private void UpdateAnimationMovement(Vector2 move)
    {
        if (move.x != 0)
        {
            animator.SetFloat(AnimatorLastX, move.x);
        }

        if (move.x < 0)
        {
            root.transform.rotation = Quaternion.Euler(0, 180, 0);
            headChanger.SetCategoryAndLabel("HeadPlayer", "Black");
        }
        else if (move.x > 0)
        {
            root.transform.rotation = Quaternion.Euler(0, 0, 0);
            headChanger.SetCategoryAndLabel("HeadPlayer", "White");
        }

        animator.SetFloat(AnimatorVMovementX, move.x);
        animator.SetFloat(AnimatorVMovementY, move.y);
        animator.SetBool(AnimatorMoving, move.x != 0);
    }

    private void OnReloadScene()
    {
        ChangePlayerComponents(true);
    }

    private void OnPlayerJump()
    {
        animator.SetTrigger(AnimatorJumpTrig);
    }

    private void OnEnable()
    {
        PlayerPlatformInput.OnDash += OnDash;
        PlayerPlatformInput.OnPlayerMove += UpdateAnimationMovement;
        GameManagePlatform.OnReloadGame += OnReloadScene;
        PlayerPlatformInput.OnPlayerJump += OnPlayerJump;
    }

    private void OnDash()
    {
        animator.SetTrigger(AnimatorDash);
    }


    private void OnDisable()
    {
        PlayerPlatformInput.OnDash -= OnDash;
        PlayerPlatformInput.OnPlayerJump -= OnPlayerJump;
        PlayerPlatformInput.OnPlayerMove -= UpdateAnimationMovement;
        GameManagePlatform.OnReloadGame -= OnReloadScene;
    }
}