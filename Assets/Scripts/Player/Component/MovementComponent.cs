using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    InputComponent inputs = null;
    Rigidbody2D playerRigidBody = null;
    Detection detection = null;
    [Header("-----Animation-----")]
    [SerializeField] Animator animator = null;


    [Header("-----Variable-----")]
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float moveSpeed = 2.0f;

    [SerializeField] float jumpForce = 16.0f;
    [SerializeField] bool canJump = true;

    [SerializeField] float dashForce = 3.0f;
    [SerializeField] bool isDashing;
    [SerializeField] bool canDash = true;
    [SerializeField] float dashTime = 0.2f;
    [SerializeField] float dashCooldown = 1.0f;

    [SerializeField] float currentDirection = 0.0f;
    float originalGravity;


    public Animator Animator => animator;
    public bool CanJump { get => canJump; set { canJump = value; } }
    private void Start()
    {
        Init();
        BindEvent();
        originalGravity = playerRigidBody.gravityScale;

    }

    private void Init()
    {
        inputs = GetComponent<InputComponent>();
        playerRigidBody = GetComponentInParent<Rigidbody2D>();
        detection = transform.GetComponentInChildren<Detection>();
    }

    private void BindEvent()
    {
        inputs.JumpAction.performed += Jump;
        inputs.AttackAction.performed += Attack;
        inputs.DashAction.performed += Dash;
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsJumping", detection.IsJumping);
        animator.SetBool("IsFalling", detection.IsFalling);

        if (isDashing) return;

        Move(inputs.MoveAction.ReadValue<float>());
    }

    private void Move(float _direction)
    {
        float _dir = _direction > 0 ? 1 : _direction < 0 ? -1 : _direction;
        transform.position += new Vector3(_dir * moveSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
        isFacingRight = _dir > 0 ? true : _dir < 0 ? false : isFacingRight;
        if (_dir != 0)
            transform.localScale = new Vector3(_dir * 1.0f, 1.0f, 1.0f);
        else 
            transform.localScale = isFacingRight ? new Vector3((_dir + 1.0f) * 1.0f , 1.0f, 1.0f) : new Vector3((_dir - 1.0f) * 1.0f, 1.0f, 1.0f);
        currentDirection = _dir;
        animator.SetFloat("Direction", Mathf.Abs(_dir));

    }

    private void Jump(InputAction.CallbackContext _context)
    {
        if (!canJump || isDashing) return;
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        detection.IsJumping = true;
        canJump = false;

    }

    private void Attack(InputAction.CallbackContext _context)
    {
    }
    private void Dash(InputAction.CallbackContext _context)
    {
        if (!canDash) return;
        canDash = false;
        isDashing = true;
        animator.SetBool("IsDashing", isDashing);
        //No gravity
        playerRigidBody.gravityScale = 0.0f;
        //Dash speed
        playerRigidBody.velocity = new Vector2(Mathf.Clamp(transform.localScale.x, -1, 1) * dashForce, 0.0f);

        Invoke(nameof(ResetGravity), dashTime);
        Invoke(nameof(ResetCanDash), dashCooldown);
        
    }

    private void ResetGravity()
    {
        playerRigidBody.gravityScale = originalGravity;
        playerRigidBody.velocity = new Vector2(0.0f, 0.0f);
        isDashing = false;
        animator.SetBool("IsDashing", isDashing);

    }
    private void ResetCanDash()
    {
        canDash = true;
    }
}
