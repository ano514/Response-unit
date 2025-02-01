using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerHUD : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField]private ProgressBar healthBar;
    [SerializeField] private ProgressBar1 ShieldBar;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetVaules(currentHealth, maxHealth);
    }

    public void UpdateShield(int Shield, int maxShield)
    {
        ShieldBar.SetVaules(Shield, maxShield);
    }

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
}
