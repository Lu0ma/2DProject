using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    InputComponent inputs = null;
    Rigidbody2D playerRigidBody = null;
    Detection detection = null;

    [Header("-----Variable-----")]
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
        detection = transform.parent.GetComponentInChildren<Detection>();
    }

    private void BindEvent()
    {
        inputs.JumpAction.performed += Jump;
        inputs.AttackAction.performed += Attack;
        inputs.DashAction.performed += Dash;
    }

    private void Update()
    {
        if (inputs.MoveAction.ReadValue<float>() == 0 || isDashing) return;
        Move(inputs.MoveAction.ReadValue<float>());
    }

    private void Move(float _direction)
    {
        transform.parent.position += new Vector3(_direction * moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        transform.localScale = new Vector3(_direction * 3.0f, _direction * 3.0f, 1.0f);
        currentDirection = _direction;
    }

    private void Jump(InputAction.CallbackContext _context)
    {
        if (!canJump || isDashing) return;
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
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
        //No gravity
        playerRigidBody.gravityScale = 0.0f;
        //Dash speed
        playerRigidBody.velocity = new Vector2(currentDirection * dashForce, 0.0f);

        Invoke(nameof(ResetGravity), dashTime);
        Invoke(nameof(ResetCanDash), dashCooldown);
        
    }

    private void ResetGravity()
    {
        playerRigidBody.gravityScale = originalGravity;
        playerRigidBody.velocity = new Vector2(0.0f, 0.0f);
        isDashing = false;
    }
    private void ResetCanDash()
    {
        canDash = true;
    }
}
