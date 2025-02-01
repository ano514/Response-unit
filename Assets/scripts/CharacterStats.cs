using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]protected int Health;
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected int Shield;
    [SerializeField] protected int MaxShield;
    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
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
    public void InitVariables()
    {
        MaxHealth = 100;
        MaxShield = 50;
        SetHealthTo(MaxHealth);
        SetShieldTo(MaxShield);
        isDead = false;
    }
}
