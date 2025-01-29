
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawner : MonoBehaviour
{
    public Transform gunTip;
    private Inventory inventory;
    private EquipmentManager manager;
    private AmmoManager ammoManager;
    private float lastShootTime = 0;
    private bool canShoot;
    private bool aim = false;


    [SerializeField] private int CurrentAmmo;
    [SerializeField] private int CurrentAmmoStorage;
    [SerializeField] private TrailRenderer BulletTrial;
    private void Start()
    {
        Reference();
        canShoot = true;
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
        else if ((int)inventory.GetItem(manager.current).firemode == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0)) // Left mouse button or assigned key
            {
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoManager.Reload(manager.current);
        }
        if (Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.R))
        {
            aim = true;

        }
        else
        {
            aim = false;

        }

    }

    private void RaycastShoot(weapon currentWeapon)
    {
        RaycastHit hit;

        float spread = currentWeapon.spread;
        float currentWeaponRange = currentWeapon.range;
        if (aim)
        { spread = spread * 0.5f; }

        Vector3 direction = Direction(spread);

        if (Physics.Raycast(gunTip.position, direction, out hit, currentWeaponRange))
        {
            TrailRenderer trail = Instantiate(BulletTrial, gunTip.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawRay(gunTip.position, direction, Color.green);
        }
    }

    private void Shoot()
    {
        CheckCanShoot(manager.current);
        if (canShoot)
        {
            weapon currentWeapon = inventory.GetItem(manager.current);

            if (Time.time > lastShootTime + currentWeapon.fireRate)
            {
                Debug.Log("Shoot");
                lastShootTime = Time.time;

                RaycastShoot(currentWeapon);
                ammoManager.UseAmmo((int)currentWeapon.weaponstyle, 1, 0);
            }
        }
        else
            Debug.Log("Naser si nemas naboje preby dopukla");

    }
    public void CheckCanShoot(int slot)
    {
        if (slot == 0)
        {
            if (ammoManager.getprimaryMagazineIsEmpty())
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
        if (slot == 1)
        {
            if (ammoManager.getsecondaryMagazineIsEmpty())
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
        }
    }


    private void Reference()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
        ammoManager = GetComponentInParent<AmmoManager>();

    }

    private Vector3 Direction(float spread)
    {
        Vector3 direction = gunTip.forward;
        direction += new Vector3(
            Random.Range(-spread, spread),
            Random.Range(-spread, spread),
            Random.Range(-spread, spread)
            );
        direction.Normalize();

        return direction;
    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPositon = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPositon, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;
        Destroy( Trail.gameObject, Trail.time );
    }
}