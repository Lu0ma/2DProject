using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    IA_Player controls = null;

    InputAction moveAction = null;
    InputAction jumpAction = null;
    InputAction attackAction = null;
    InputAction dashAction = null;

    public InputAction MoveAction => moveAction;
    public InputAction JumpAction => jumpAction;
    public InputAction AttackAction => attackAction;
    public InputAction DashAction => dashAction;


    private void Awake()
    {
        controls = new IA_Player();
    }

    private void OnEnable()
    {
        moveAction = controls.Player.Move;
        moveAction.Enable();
        jumpAction = controls.Player.Jump;
        jumpAction.Enable();
        attackAction = controls.Player.Attack;
        attackAction.Enable();
        dashAction = controls.Player.Dash;
        dashAction.Enable();
    }
}
