
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform gunTip; 
    private Inventory inventory;
    private EquipmentManager manager;
    private AmmoManager managerAmmo;
    private float lastShootTime = 0;

    [SerializeField] private int CurrentAmmo;
    [SerializeField] private int CurrentAmmoStorage;


    private void Start()
    {
        Reference();
    }

    private void Update()
    {
        if ((int)inventory.GetItem(manager.current).firemode != 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Left mouse button or assigned key
            {
                Shoot();
            }
        }
        else if((int) inventory.GetItem(manager.current).firemode == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0)) // Left mouse button or assigned key
            {
                Shoot();
            }
        }

    }

    private void RaycastShoot(weapon currentWeapon)
    {
        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }

    private void Shoot()
    {
        weapon currentWeapon = inventory.GetItem(manager.current);

        if(Time.time > lastShootTime+currentWeapon.fireRate)
        {
            Debug.Log("Shoot");
            lastShootTime= Time.time;

            RaycastShoot(currentWeapon);
            managerAmmo.UseAmmo((int)currentWeapon.weaponstyle, 1, 0);
        }
    }

    private void Reference()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
        managerAmmo = GetComponentInParent<AmmoManager>();
    }
    
}