using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerHUD : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField]private ProgressBar healthBar;
    [SerializeField] private ProgressBar1 ShieldBar;
    [SerializeField] private ShowAmmo ammo;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetVaules(currentHealth, maxHealth);
    }

    public void UpdateWeapinUI(weapon newWeapon)
    {
        ammo.UpdateInfo(newWeapon.magdazineSize, newWeapon.magazineCount*newWeapon.magdazineSize);
    }

    public void UpdateWeaponAmmoUI(int curentAmmo, int storedAmmo)
    {
        ammo.UpdateAmmoUI(curentAmmo, storedAmmo);
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
