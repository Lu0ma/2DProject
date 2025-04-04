using UnityEngine;

public class Player : MonoBehaviour
{
    MovementComponent movement = null;
    Ray ray = new();

    [Header("-----Variable-----")]
    [SerializeField] LayerMask layers = 0;
    [Header("-----DEBUG-----")]
    [SerializeField] float rayLength = 1.5f;
    void Start()
    {
        movement = GetComponent<MovementComponent>();
        ray = new Ray(transform.position, -transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHittingGround())
        {
            print("Ground Hit");
            movement.CanJump = true;
        }
    }

    private bool IsHittingGround()
    {
        return Physics2D.Raycast(transform.position, -transform.up, rayLength, layers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * rayLength);
    }
}
