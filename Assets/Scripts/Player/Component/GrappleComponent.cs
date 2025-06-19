using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleComponent : MonoBehaviour
{
    InputComponent inputsRef = null;

    [SerializeField] float grapplingMaxRange = 50.0f;
    void Start()
    {
        inputsRef = GetComponent<InputComponent>();
        inputsRef.GrappleAction.performed += Grapple;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Grapple(InputAction.CallbackContext _context)
    {
        
        Gizmos.DrawLine(transform.position, transform.position + (transform.right + transform.up * 1.5f) * grapplingMaxRange);

    }

    private void OnDrawGizmos()
    {
    }
}
