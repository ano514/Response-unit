using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    private void Start()
    {
        References();
        InitVariables();
    }

    private void References()
    {
        hud = GetComponent<PlayerHUD>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(Health,MaxHealth);
    }

    public override void CheckShield()
    {
        base.CheckShield();
        hud.UpdateShield(Shield, MaxShield);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
}
