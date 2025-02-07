
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletSpawnerEnemy : MonoBehaviour
{
    public Transform gunTip;
    private Terorist Terorist;
    private float lastShootTime = 0;
    private bool canShoot;
    private bool aim = false;


    [SerializeField] private int CurrentAmmo;
    [SerializeField] private TrailRenderer BulletTrial;
    private void Start()
    {
        Reference();
        canShoot = true;
    }

    private void Update()
    {
        
    }

    private void RaycastShoot(weapon Weapon)
    {
        RaycastHit hit;

        float spread = Weapon.spread;
        if (aim)
        { spread = spread * 0.5f; }

        Vector3 direction = Direction(spread);

        if (Physics.Raycast(gunTip.position, direction, out hit))
        {
            TrailRenderer trail = Instantiate(BulletTrial, gunTip.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            if (hit.collider.tag == "Player")
            {
                CharacterStats playerStats = hit.collider.GetComponent<CharacterStats>();
                playerStats.TakeDamage(Weapon.damage);
            }
            if (hit.collider.tag == "Civil")
            {
                CharacterStats civilStats = hit.collider.GetComponent<CharacterStats>();
                civilStats.TakeDamage(Weapon.damage);
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            weapon currentWeapon = Terorist.deafultWeapon;

            if (Time.time > lastShootTime + currentWeapon.fireRate)
            {
                lastShootTime = Time.time;

                RaycastShoot(Terorist.deafultWeapon);
                Terorist.UseAmmo(1);
            }
        }

    }

    private void Reference()
    {
        Terorist = GetComponentInParent<Terorist>();

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
    public void CheckCanShoot()
    {
        if (Terorist.MagazineIsEmpty)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }
}