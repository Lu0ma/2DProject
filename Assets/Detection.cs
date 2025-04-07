using UnityEngine;

public class Detection : MonoBehaviour
{
    MovementComponent movement = null;
    [SerializeField] bool isGrounded = true;
    public bool IsGrounded { get => isGrounded; set { isGrounded = value; } }

    private void Start()
    {
        movement = transform.parent.GetComponentInChildren<MovementComponent>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            movement.CanJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Invoke(nameof(JumpAnnulation), 0.3f);
        }
    }

    private void JumpAnnulation()
    {
        movement.CanJump = false;
    }
}
