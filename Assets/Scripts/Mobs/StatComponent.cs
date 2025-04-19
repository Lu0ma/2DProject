using UnityEngine;

public class StatComponent : MonoBehaviour
{
    [Header("-----Variable-----")]
    [SerializeField] int maxLife = 10;
    [SerializeField] int currentLife = 10;


    [SerializeField] bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }
    public int CurrentLife { get => currentLife; set => currentLife = value; }

    private bool VerifyLife()
    {
        isDead = currentLife > 0 ? false : true;
        //movement.Animator.SetBool("IsDead", isDead);
        return !isDead;
    }

}
