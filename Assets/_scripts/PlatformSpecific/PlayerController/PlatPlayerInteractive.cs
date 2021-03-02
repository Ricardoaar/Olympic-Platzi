using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Experimental.U2D.Animation;

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
    private static readonly int LastX = Animator.StringToHash("LastX");

    private readonly List<GameObject> _rootChild = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("DamagePlayer")) return;

        if (other.transform.parent.TryGetComponent(typeof(GhostBehavior), out var dummy))
        {
            //    CollisionWithGhost(other);
        }

        //CollisionWithEnemy();
    }

    private void CollisionWithEnemy()
    {
        var mainParticleModule = onDieParticles.main;
        mainParticleModule.startColor = root.transform.eulerAngles.y == 0 ? dieParticleColor : Color.black;
        Instantiate(onDieParticles, transform.position, Quaternion.identity);
        OnDamage.Invoke();
        ChangePlayerComponents(false);
    }

    private void CollisionWithGhost(Collision2D ghost)
    {
        var ghostType = ghost.transform.parent.GetComponent<GhostBehavior>();

        switch (ghostType.GetGhostType)
        {
            case GhostBehavior.GhostType.Dark
                when root.transform.rotation == Quaternion.Euler(new Vector3(0, 180, 0)):
                ghostType.Die();
                return;
            case GhostBehavior.GhostType.White when root.transform.rotation == Quaternion.identity:
                ghostType.Die();
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
        animator.SetBool(AnimatorGroundCheck, checker.CheckRayToLayer());
        if (checker.GetRay(2))
        {
            animator.SetFloat(AnimatorGroundDistance, checker.GetRay(2).distance);
        }
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
            animator.SetFloat(LastX, move.x);
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
        PlayerPlatformInput.OnPlayerMove += UpdateAnimationMovement;
        GameManagePlatform.OnReloadGame += OnReloadScene;
        PlayerPlatformInput.OnPlayerJump += OnPlayerJump;
    }

    private void OnDisable()
    {
        PlayerPlatformInput.OnPlayerJump -= OnPlayerJump;
        PlayerPlatformInput.OnPlayerMove -= UpdateAnimationMovement;
        GameManagePlatform.OnReloadGame -= OnReloadScene;
    }
}