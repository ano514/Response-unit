using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager manager;
    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;
    [SerializeField] private int secondariCurrentAmmo;
    [SerializeField] private int secondariCurrentAmmoStorage;
    private void Start()
    {
        Reference();
    }
    public void InitAmmo(int slot, weapon Weapon)
    {
        if (slot == 0)
        {
            primaryCurrentAmmo = Weapon.magdazineSize;
            primaryCurrentAmmoStorage = Weapon.magdazineSize * Weapon.magazineCount;
        }
        if (slot == 1)
        {
            secondariCurrentAmmo = Weapon.magdazineSize;
            secondariCurrentAmmoStorage = Weapon.magdazineSize * Weapon.magazineCount;
        }


    }
    public void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        if (slot == 0)
        {
            primaryCurrentAmmo -= currentAmmoUsed;
            primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
        }
        if (slot == 1)
        {
            secondariCurrentAmmo -= currentAmmoUsed;
            secondariCurrentAmmoStorage -= currentStoredAmmoUsed;
        }
    }
    private void Reference()
    {
        inventory = GetComponent<Inventory>();
        manager = GetComponentInChildren<EquipmentManager>();
    }

}