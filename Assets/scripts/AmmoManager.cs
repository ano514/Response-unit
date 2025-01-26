using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager manager;
    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;
    [SerializeField] private int secondaryCurrentAmmo;
    [SerializeField] private int secondaryCurrentAmmoStorage;
    [SerializeField] private bool primaryMagazineIsEmpty=true;
    [SerializeField] private bool secondaryMagazineIsEmpty = true;
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
            if (primaryCurrentAmmo <= 0)
            {
                primaryMagazineIsEmpty = true;
            }
            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }
        }
        if (slot == 1)
        {
            if (secondaryCurrentAmmo <= 0)
            {
                secondaryMagazineIsEmpty = true;
            }
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }
        }
    }
    private void Reference()
    {
        inventory = GetComponent<Inventory>();
        manager = GetComponentInChildren<EquipmentManager>();
    }

    public bool getprimaryMagazineIsEmpty()
    {
        return primaryMagazineIsEmpty;
    }
    public bool getsecondaryMagazineIsEmpty()
    {
        return secondaryMagazineIsEmpty;
    }

}