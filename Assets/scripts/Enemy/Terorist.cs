using UnityEngine;

public class Terorist : MonoBehaviour
{
    [SerializeField] public weapon deafultWeapon = null;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private Transform GunHolder = null;
    private GameObject Current;
    private Animator anim;
    private BulletSpawnerEnemy spawner;
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

}
