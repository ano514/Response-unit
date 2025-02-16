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
    }

  
    public void EquipWeapon(weapon Weapon)
    {
        current = (int)Weapon.weaponstyle;
        anim.SetInteger("Typ", (int)Weapon.type);
        inventoriGun= Instantiate(Weapon.prefab, GunInventory);
        currentGun = Instantiate(Weapon.prefab, GunHolder);
        HUD.UpdateWeapinUI(Weapon);

    }
     private void UnequipWeapon()
    {
        anim.SetTrigger("Prepnut");
        Destroy(currentGun);
        Destroy(inventoriGun);
    }
}
