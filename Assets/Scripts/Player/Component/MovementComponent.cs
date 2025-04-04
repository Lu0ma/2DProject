using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    InputComponent inputs = null;
    Rigidbody2D playerRigidBody = null;
    

    [Header("-----Variable-----")]
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float jumpForce = 3.0f;
    [SerializeField] bool canJump = true;
    public bool CanJump { set { canJump = value; } }
    private void Start()
    {
        Init();
        BindEvent();
    }

    private void Init()
    {
        inputs = GetComponent<InputComponent>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void BindEvent()
    {
        inputs.JumpAction.performed += Jump;
        inputs.AttackAction.performed += Attack;
    }

    private void Update()
    {
        if (inputs.MoveAction.ReadValue<float>() == 0) return;
        Move(inputs.MoveAction.ReadValue<float>());
    }

    private void Move(float _direction)
    {
        transform.position += new Vector3(_direction * moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        transform.localScale = new Vector3(_direction, _direction, 1.0f);
    }

    private void Jump(InputAction.CallbackContext _context)
    {
        if (!canJump) return;
        playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
        canJump = false;
    }

    private void Attack(InputAction.CallbackContext _context)
    {
    }

}
