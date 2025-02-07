using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager manager;
    private BulletSpawner spawner;
    private ShowAmmo ammo;
    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;
    [SerializeField] private int secondaryCurrentAmmo;
    [SerializeField] private int secondaryCurrentAmmoStorage;
    [SerializeField] private bool primaryMagazineIsEmpty=false;
    [SerializeField] private bool secondaryMagazineIsEmpty =false;
    private void Start()
    {
        Reference();
    }
    public void InitAmmo(int slot, weapon Weapon)
    {
        Debug.Log((int)Weapon.weaponstyle);
        if (slot == 0)
        {
            Debug.Log("Mozem pridat naboje");
            primaryCurrentAmmo = (int)Weapon.magdazineSize;
            primaryCurrentAmmoStorage = (int)Weapon.magdazineSize * (int)Weapon.magazineCount;
        }
        if (slot == 1)
        {
            Debug.Log("Mozem pridat naboje");
            secondaryCurrentAmmo = (int)Weapon.magdazineSize;
            secondaryCurrentAmmoStorage = (int)Weapon.magdazineSize * (int)Weapon.magazineCount;
        }


    }
    public void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        if (slot == 0)
        {
            if (primaryCurrentAmmo <= 0)
            {
                primaryMagazineIsEmpty = true;
                spawner.CheckCanShoot(manager.current);
            }
            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
                ammo.UpdateAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
            }
        }
        if (slot == 1)
        {
            if (secondaryCurrentAmmo <= 0)
            {
                secondaryMagazineIsEmpty = true;
                spawner.CheckCanShoot(manager.current);
            }
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentAmmoStorage -= currentStoredAmmoUsed;
                ammo.UpdateAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
            }
        }
    }
    public void Reload(int slot)
    {
        if (slot == 0)
        {
            if (primaryCurrentAmmoStorage >= inventory.GetItem(0).magdazineSize)
           {   
            if (primaryCurrentAmmo == inventory.GetItem(0).magdazineSize)
                Debug.Log("Si debil strelaj mas plne");
            primaryCurrentAmmoStorage -= (inventory.GetItem(0).magdazineSize-primaryCurrentAmmo);
            primaryCurrentAmmo = inventory.GetItem(0).magdazineSize;
                ammo.UpdateAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
            primaryMagazineIsEmpty=false;
                spawner.CheckCanShoot(slot);
            }
        }
        if (slot == 1)
        {
            if (secondaryCurrentAmmoStorage >= inventory.GetItem(0).magdazineSize)
            {
                if (secondaryCurrentAmmo == inventory.GetItem(0).magdazineSize)
                    Debug.Log("Si debil strelaj mas plne");
                secondaryCurrentAmmoStorage -= (inventory.GetItem(1).magdazineSize - secondaryCurrentAmmo);
                secondaryCurrentAmmo = inventory.GetItem(1).magdazineSize;
                ammo.UpdateAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
                secondaryMagazineIsEmpty = false;
                spawner.CheckCanShoot(slot);
            }
        }
    }
    private void Reference()
    {
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
        spawner = GetComponentInChildren<BulletSpawner>();
        ammo = GetComponent<ShowAmmo>();
    }

    public bool getprimaryMagazineIsEmpty()
    {
        return primaryMagazineIsEmpty;
    }
    public bool getsecondaryMagazineIsEmpty()
    {
        return secondaryMagazineIsEmpty;
    }
    public void setprimaryCurrentAmmo (int value)
    {
        primaryCurrentAmmo = value;
    }
    public void setprimaryCurrentAmmoStorage(int value)
    {
        primaryCurrentAmmoStorage = value;
    }
    public void setsecodnaryCurrentAmmo(int value)
    {
        secondaryCurrentAmmo = value;
    }
    public void setsecondaryCurrentAmmoStorage(int value)
    {
        secondaryCurrentAmmoStorage = value;
    }

}