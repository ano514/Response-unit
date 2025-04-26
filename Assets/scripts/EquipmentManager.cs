using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    public int current = 2;
    public GameObject currentGun = null;
    public GameObject inventoriGun = null;
    [SerializeField] private Transform GunHolder = null;
    [SerializeField] private Transform GunInventory = null;
    private Animator anim;
    private Inventory inventory;
    private BulletSpawner bulletSpawner;
    private PlayerHUD HUD;
    private AmmoManager ammo;

    [SerializeField] weapon deafultWeapon = null;
    private void Start()
    {
        GetRefetences();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && current != 0)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));

            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && current != 1)
        {
            
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(1));


        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && current != 2)
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(2));


        }
    }
    
    private void GetRefetences()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        bulletSpawner = GetComponent<BulletSpawner>();
        HUD = GetComponent<PlayerHUD>();
        ammo = GetComponent<AmmoManager>();
    }

  
    public void EquipWeapon(weapon Weapon)
    {
        current = (int)Weapon.weaponstyle;
        anim.SetInteger("Typ", (int)Weapon.type);
        inventoriGun= Instantiate(Weapon.prefab, GunInventory);
        currentGun = Instantiate(Weapon.prefab, GunHolder);
        if ((int)Weapon.weaponstyle == 0)
        {
            HUD.UpdateWeaponAmmoUI(ammo.getprimaryCurrentAmmo(),ammo.getprimaryCurrentAmmoStorage());
        }
        else if ((int)Weapon.weaponstyle == 1) 
            {
            
                HUD.UpdateWeaponAmmoUI(ammo.getsecodnaryCurrentAmmo(), ammo.getsecondaryCurrentAmmoStorage());
            }
        }
     private void UnequipWeapon()
    {
        anim.SetTrigger("Prepnut");
        Destroy(currentGun);
        Destroy(inventoriGun);
    }
}
