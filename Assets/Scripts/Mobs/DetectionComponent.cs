using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class DetectionComponent : MonoBehaviour
{
    MobMovementComponent movementRef = null;
    bool isTarget;
    bool isGround;
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] LayerMask playerLayer = 0;
    [SerializeField] float groundDistance = 2.0f;
    [SerializeField] float playerDistance = 2.0f;
    Vector3 playerDir = Vector3.zero;
    public bool IsTarget { get => isTarget; set => isTarget = value; }
    public bool IsGround { get => isGround; set => isGround = value; }
    public Vector3 PlayerDir { get => playerDir; set => playerDir = value; }

    void Start()
    {
        movementRef = GetComponent<MobMovementComponent>();
    }

    void FixedUpdate()
    {
        PlayerDetection();
        GroundDetection();
    }

    private void PlayerDetection()
    {

        RaycastHit2D _playerHit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, playerDistance * 1.5f, playerLayer);

        if (!_playerHit)
        {
            isTarget = false;
            return;
        }
        if (_playerHit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isTarget = true;
            playerDir = _playerHit.collider.transform.position;
            return;
        }
    }
    private void GroundDetection()
    {
        RaycastHit2D _groundHit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x + -transform.up, groundDistance, groundLayer);
        if (!_groundHit)
        {
            isGround = false;
            movementRef.Rotate();
            return;
        }
        if (_groundHit.rigidbody.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, (-transform.right * transform.localScale.x) * playerDistance);
        //Gizmos.color = Color.green;
        //Gizmos.DrawRay(transform.position, (-transform.right * transform.localScale.x - (transform.up /2.0f)) * distance);
    }
}
