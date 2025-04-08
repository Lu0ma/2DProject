using UnityEngine;

public class StatComponent : MonoBehaviour
{
    MovementComponent movement = null;

    [Header("-----Variable-----")]
    [SerializeField] int maxLife = 10;
    [SerializeField] int currentLife = 10;
    
    [SerializeField] int maxMana = 10;
    [SerializeField] int currentMana= 10;

    [SerializeField] float invisibilityMaxTime = 1.0f;
    [SerializeField] float currentInvisibilityTime = 0.0f;

    [SerializeField] bool isDead = false;

    private void Start()
    {
        movement = GetComponent<MovementComponent>();
    }

    public int CurrentLife { get => currentLife; set { currentLife = value; } }
    public int CurrentMana{ get => currentMana; set { currentMana = value; } }

    private bool VerifyLife()
    {
        isDead = currentLife > 0 ? false : true;
        movement.Animator.SetBool("IsDead", isDead);
        return !isDead;
    }

    private bool VerifyMana()
    {
        return currentMana > 0 ? true : false;
    }

    private void TakeDamage()
    {
        movement.Animator.SetTrigger("Damage");
    }
}
