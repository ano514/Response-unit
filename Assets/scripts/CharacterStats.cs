using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]protected int Health;
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected int Shield;
    [SerializeField] protected int MaxShield;
    [SerializeField] protected bool isDead;
    [SerializeField] protected int health;
    [SerializeField] protected int shield;


    private void Start()
    {
        InitVariables(health,shield);
    }
    public virtual void CheckHealth()
    {
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        
    }
    public virtual void CheckShield()
    {
        if (Shield <= 0)
        {
            Shield = 0;
        }
        if (Shield >= MaxShield)
        {
            Shield = MaxShield;
        }
    }
    public void Die()
    {
        isDead = true;
    }
    public void SetHealthTo(int healthToSetTo)
    {
        Health = healthToSetTo;
        CheckHealth();
    }
    public void SetShieldTo(int shieldToSetTo)
    {
        Shield = shieldToSetTo;
        CheckHealth();
    }
    public void TakeDamage(int damage)
    {
        if (Shield <= 0) {
            int healthAfterDamage = Health - damage;
            SetHealthTo(healthAfterDamage);
        }
        else
        {
            int ShieldAfterDamage = Shield - damage;
            SetShieldTo(ShieldAfterDamage);
        }
    }
    public void InitVariables(int health,int shield)
    {
        MaxHealth = health;
        MaxShield = shield;
        SetHealthTo(MaxHealth);
        SetShieldTo(MaxShield);
        isDead = false;
    }
}
