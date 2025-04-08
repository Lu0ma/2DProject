using UnityEngine;

public class Detection : MonoBehaviour
{
    MovementComponent movement = null;
    [SerializeField] bool isFalling = false;
    [SerializeField] bool isJumping= false;
    public bool IsFalling { get => isFalling; set { isFalling = value; } }
    public bool IsJumping { get => isJumping; set { isJumping = value; } }

    private void Start()
    {
        movement = transform.parent.GetComponentInChildren<MovementComponent>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isFalling = false;
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

    //Allow the player to jump later after falling
    private void JumpAnnulation()
    {
        isFalling = true;        
        movement.CanJump = false;
        isJumping = false;
    }
}
