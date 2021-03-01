using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class PlatPlayerInteractive : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject root;
    [SerializeField] private SpriteResolver headChanger;
    [SerializeField] private RayLayerChecker checker;

    private static readonly int AnimatorVMovementX = Animator.StringToHash("MoveX");
    private static readonly int AnimatorVMovementY = Animator.StringToHash("MoveY");
    private static readonly int AnimatorMoving = Animator.StringToHash("Moving");
    private static readonly int AnimatorJumpTrig = Animator.StringToHash("Jump");
    private static readonly int AnimatorGroundCheck = Animator.StringToHash("IsOnGround");
    private static readonly int AnimatorGroundDistance = Animator.StringToHash("DistanceToGround");
    private static readonly int LastX = Animator.StringToHash("LastX");

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


    private void OnPlayerJump()
    {
        animator.SetTrigger(AnimatorJumpTrig);
    }

    private void OnEnable()
    {
        PlayerPlatformInput.OnPlayerMove += UpdateAnimationMovement;
        PlayerPlatformInput.OnPlayerJump += OnPlayerJump;
    }

    private void OnDisable()
    {
        PlayerPlatformInput.OnPlayerJump -= OnPlayerJump;
        PlayerPlatformInput.OnPlayerMove -= UpdateAnimationMovement;
    }
}