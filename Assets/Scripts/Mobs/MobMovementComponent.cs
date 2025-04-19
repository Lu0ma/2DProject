using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovementComponent : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] float moveSpeed = 0.5f;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Animator Animator => animator;
    public void Move()
    {
        transform.position += (-transform.right * transform.localScale.x) * moveSpeed * Time.fixedDeltaTime;
    }

    public void Rotate()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void MoveToPlayer(Vector3 _playerDir)
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerDir, moveSpeed * Time.fixedDeltaTime);
        print("Move To Player");
    }
}
