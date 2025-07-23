using System.Collections;
using UnityEngine;
public class PlayerStatsComponents : StatComponent
{
    MovementComponent movement = null;
	[SerializeField] Canvas canvas = null;
	[SerializeField] GameObject lifePrefab = null;
	[SerializeField] int maxMana = 10;
    [SerializeField] int currentMana = 10;

    [SerializeField] float invisibilityMaxTime = 1.0f;
    [SerializeField] float currentInvisibilityTime = 0.0f;
    [SerializeField] int currentMoney = 0;
    public int CurrentMana { get => currentMana; set => currentMana = value; }

    private void Start()
    {
        movement = GetComponent<MovementComponent>();

		StartCoroutine(CreateLife());
	}
	private IEnumerator CreateLife()
    {
		for (int i = 0; i < MaxLife; i++)
		{
		    yield return new WaitForSeconds(0.1f);
		    Instantiate(lifePrefab, new Vector3(100.0f + i * 50.0f, 1000.0f, 0.0f), new Quaternion(), canvas.transform);
		}
	}
	private void Update()
	{
		
	}

	private bool VerifyLife()
    {
        IsDead = CurrentLife > 0 ? false : true;
        movement.Animator.SetBool("IsDead", IsDead);
        return !IsDead;
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
