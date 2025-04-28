using UnityEngine;
using UnityEngine.AI;

public class Terorist : MonoBehaviour
{
    [SerializeField] public weapon deafultWeapon = null;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private Transform GunHolder = null;
    private GameObject Current;
    private Animator anim;
    private BulletSpawnerEnemy spawner;
    private NavMeshAgent agent;
    private bool flash = false;
    private float flashdelay = 5f;
    public bool MagazineIsEmpty = false;
    private void Start()
    {
        References();
        Deafaultweapon(deafultWeapon);
        InitAmmo();
    }
    private void Update()
    {
        if (CurrentAmmo <= 0)
        {
            Reload();
        }
        if (flash==true)
        {
            flashdelay -= Time.deltaTime;
            if(flashdelay <= 0)
            {
                flash = false;
                flashdelay = 5f;
                agent.isStopped = false;
            }
        }

    }
    private void EquipWeapon(weapon Weapon)
    {
        anim.SetInteger("Typ", (int)Weapon.type);
        Current = Instantiate(Weapon.prefab, GunHolder);
    }
    private void References()
    {
        anim = GetComponentInChildren<Animator>();
        spawner = GetComponent<BulletSpawnerEnemy>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Deafaultweapon(weapon Weapon)
        {
        EquipWeapon(Weapon);
        }

    private void InitAmmo()
    {
        CurrentAmmo = deafultWeapon.magdazineSize;
    }
    private void Reload()
    {
        CurrentAmmo = deafultWeapon.magdazineSize;
    }
    public void UseAmmo(int currentAmmoUsed)
    {
        if (CurrentAmmo <= 0)
        {
            MagazineIsEmpty = true;
            spawner.CheckCanShoot();
        }
        else
        {
            CurrentAmmo -= currentAmmoUsed;
        }
    }
    public bool getMagazineIsEmpty()
    {
        return MagazineIsEmpty;
    }
    public weapon getDeafaultWeapon()
    {
        return deafultWeapon;
    }
    public void Arrest()
    {
        if (anim.GetBool("Surender"))
        {
            anim.SetBool("Surender", false);
            anim.SetBool("Arrest", true);
            PointSystem.EnemyArrestAddPoint(1);
        }
    }
    public void Surender()
    {
        agent.Stop();
        anim.SetBool("Surender", true);

    }

    public void Flash()
    {
        agent.Stop();

        flash = true;
    }

}
